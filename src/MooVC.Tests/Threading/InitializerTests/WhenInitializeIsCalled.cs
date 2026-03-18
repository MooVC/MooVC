namespace MooVC.Threading.InitializerTests;

public sealed class WhenInitializeIsCalled
{
    [Test]
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
        await Assert.That(invocations).IsEqualTo(ExpectedInvocations);
        _ = await Assert.That(first).IsNotNull();
        await Assert.That(first).IsEqualTo(second);
        await Assert.That(first).IsEqualTo(third);
        await Assert.That(second).IsEqualTo(third);
    }

    [Test]
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
        await Assert.That(invocations).IsEqualTo(ExpectedInvocations);
    }

    [Test]
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
        await Assert.That(invocations).IsEqualTo(ExpectedInvocations);
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