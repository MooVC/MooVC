namespace MooVC.Threading.InitializerTests;

public sealed class WhenInitializeAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInitializerThenTheInitializerIsOnlyCalledOnceAndTheInstanceIsAlwaysTheSame()
    {
        // Arrange
        const int ExpectedInvocations = 1;
        int invocations = 0;

        Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;

            return Task.FromResult(new object());
        }

        var initializer = new Initializer<object>(Initializer);

        // Act
        object? first = await initializer.Initialize(CancellationToken.None);
        object? second = await initializer.Initialize(CancellationToken.None);
        object? third = await initializer.Initialize(CancellationToken.None);

        // Assert
        _ = invocations.Should().Be(ExpectedInvocations);
        _ = first.Should().NotBeNull();
        _ = first.Should().Be(second);
        _ = first.Should().Be(third);
        _ = second.Should().Be(third);
    }

    [Fact]
    public async Task GivenAnInitializerWhenContinueOnCapturedContextIsFalseThenTheInitializerIsOnlyCalledOnce()
    {
        // Arrange
        const int ExpectedInvocations = 1;
        int invocations = 0;

        Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;

            return Task.FromResult(new object());
        }

        var initializer = new Initializer<object>(Initializer);

        // Act
        Func<Task> act = () => GivenAnInitializerWhenContinueOnCapturedContextIsFalseThenTheInitializerIsOnlyCalledOnceActionAsync(initializer);

        await act();

        // Assert
        _ = invocations.Should().Be(ExpectedInvocations);
    }

    [Fact]
    public async Task GivenAnInitializerWithDelayThenTheInitializerIsStillCalledOnlyOnce()
    {
        // Arrange
        const int ExpectedInvocations = 1;
        int invocations = 0;

        async Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;
            await Task.Delay(500, cancellationToken);
            return new object();
        }

        var initializer = new Initializer<object>(Initializer);

        // Act
        IEnumerable<Task<object>> tasks = Enumerable
            .Range(0, 10)
            .Select(_ => initializer.Initialize(CancellationToken.None));

        _ = await Task.WhenAll(tasks);

        // Assert
        _ = invocations.Should().Be(ExpectedInvocations);
    }

    private static async Task GivenAnInitializerWhenContinueOnCapturedContextIsFalseThenTheInitializerIsOnlyCalledOnceActionAsync(
        Initializer<object> initializer)
    {
        _ = await initializer
            .Initialize(CancellationToken.None)
            .ConfigureAwait(false);

        _ = await initializer
            .Initialize(CancellationToken.None)
            .ConfigureAwait(false);

        _ = await initializer
            .Initialize(CancellationToken.None)
            .ConfigureAwait(false);
    }
}