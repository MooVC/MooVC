namespace MooVC.Threading.Coordination.CoordinatorTests;

using MooVC.Threading.Coordination;

public sealed class WhenApplyIsCalled
    : IDisposable
{
    private readonly ICoordinator<string> _coordinator;

    public WhenApplyIsCalled()
    {
        _coordinator = new Coordinator<string>();
    }

    public void Dispose()
    {
        _coordinator.Dispose();
    }

    [Fact]
    public async Task GivenAnEmptyContextThenAnArgumentNullExceptionIsThrown()
    {
        // Arrange
        string? subject = default;

        // Act
        Func<Task> act = async () => await _coordinator.Apply(subject!, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(subject));
    }

    [Fact]
    public async Task GivenADisposedCoordinatorThenAnObjectDisposedExceptionIsThrown()
    {
        // Arrange
        _coordinator.Dispose();

        // Act
        Func<Task> act = async () => await _coordinator.Apply("N/A", CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ObjectDisposedException>();
    }

    [Fact]
    public async Task GivenMultipleThreadsNoConcurrencyExceptionsAreThrown()
    {
        // Arrange
        const int ExpectedCount = 5;
        int counter = 0;
        string subject = "Test";

        Task[] tasks = CreateTasks(
            async () =>
            {
                IContext<string> coordination = await _coordinator
                    .Apply(subject, CancellationToken.None);

                using (coordination)
                {
                    counter++;
                }
            },
            ExpectedCount);

        // Act
        await Task.WhenAll(tasks);

        // Assert
        _ = counter.Should().Be(ExpectedCount);
    }

    [Fact]
    public async Task GivenATimedOutRequestThenATimeoutExceptionIsThrown()
    {
        // Arrange
        string subject = "Test";
        using var semaphore = new SemaphoreSlim(0, 1);

        // Act
        _ = Task.Run(async () =>
        {
            using (await _coordinator.Apply(subject, CancellationToken.None))
            {
                _ = semaphore.Release();
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        });

        await semaphore.WaitAsync();

        // Act
        Func<Task> act = async () => await _coordinator.Apply(subject, CancellationToken.None, TimeSpan.FromMilliseconds(250));

        // Assert
        _ = await act.Should().ThrowAsync<TimeoutException>();
    }

    [Fact]
    public async Task GivenACoordinatableContextThenItsKeyIsUsedForCoordination()
    {
        // Arrange
        string expected = Guid.NewGuid().ToString();
        ITestCoordinatable context = Substitute.For<ITestCoordinatable>();
        var subject = new Coordinator<ITestCoordinatable>();

        _ = context.GetKey().Returns(expected);

        // Act
        IContext<ITestCoordinatable> coordination = await subject
            .Apply(context, CancellationToken.None);

        // Assert
        using (coordination)
        {
            _ = context.Received(1).GetKey();
        }
    }

    [Fact]
    public async Task GivenANonCoordinatableContextThenItsStringIsUsedForCoordination()
    {
        // Arrange
        object context = Substitute.For<object>();
        var subject = new Coordinator<object>();

        // Act
        IContext<object> coordination = await subject
            .Apply(context, CancellationToken.None);

        using (coordination)
        {
            _ = context.Received(1).GetHashCode();
        }
    }

    private static Task[] CreateTasks(Func<Task> operation, int total)
    {
        var tasks = new List<Task>();

        for (int index = 0; index < total; index++)
        {
            tasks.Add(operation());
        }

        return [.. tasks];
    }
}