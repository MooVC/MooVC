namespace MooVC.Threading.InitializerTests;

using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public sealed class WhenInitializeAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInitializerThenTheInitializerIsOnlyCalledOnceAndTheInstanceIsAlwaysTheSameAsync()
    {
        const int ExpectedInvocations = 1;
        int invocations = 0;

        Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;

            return Task.FromResult(new object());
        }

        var initializer = new Initializer<object>(Initializer);

        object? first = await initializer.InitializeAsync(CancellationToken.None);
        object? second = await initializer.InitializeAsync(CancellationToken.None);
        object? third = await initializer.InitializeAsync(CancellationToken.None);

        Assert.Equal(ExpectedInvocations, invocations);
        Assert.NotNull(first);
        Assert.Equal(first, second);
        Assert.Equal(first, third);
        Assert.Equal(second, third);
    }

    [Fact]
    public async Task GivenAnInitializerWhenContinueOnCapturedContextIsFalseThenTheInitializerIsOnlyCalledOnceAsync()
    {
        const int ExpectedInvocations = 1;
        int invocations = 0;

        Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;

            return Task.FromResult(new object());
        }

        var initializer = new Initializer<object>(Initializer);

        _ = await initializer
            .InitializeAsync(CancellationToken.None)
            .ConfigureAwait(false);

        _ = await initializer
            .InitializeAsync(CancellationToken.None)
            .ConfigureAwait(false);

        _ = await initializer
            .InitializeAsync(CancellationToken.None)
            .ConfigureAwait(false);

        Assert.Equal(ExpectedInvocations, invocations);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public async Task GivenAnInitializerWhenAwaitedTogetherThenTheInitializerIsOnlyCalledOnceAsync(int threads)
    {
        const int ExpectedInvocations = 1;
        int invocations = 0;
        object expected = new();

        Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;

            return Task.FromResult(expected);
        }

        var initializer = new Initializer<object>(Initializer);

        Task<object>[] tasks = Enumerable
            .Range(1, threads)
            .Select(_ => initializer.InitializeAsync(CancellationToken.None))
            .ToArray();

        _ = await Task.WhenAll(tasks);

        Assert.Equal(ExpectedInvocations, invocations);
        Assert.All(tasks, task => Assert.Same(task.Result, expected));
    }

    [Theory]
    [InlineData(3, 10)]
    [InlineData(80, 100)]
    [InlineData(999, 1000)]
    [InlineData(0, 1000)]
    public async Task GivenAnFailingInitializerWhenAwaitedTogetherThenOutcomeThatIsReturnedRemainsUniqueAsync(int failures, int threads)
    {
        const int ExpectedSuccesses = 1;

        int invocations = 0;
        int successes = 0;
        object expected = new();

        Task<object> Initializer(CancellationToken cancellationToken)
        {
            if (invocations++ < failures)
            {
                throw new InvalidOperationException();
            }

            successes++;

            return Task.FromResult(expected);
        }

        var initializer = new Initializer<object>(Initializer);

        Task<object>[] tasks = Enumerable
            .Range(1, threads)
            .Select(_ => initializer.InitializeAsync(CancellationToken.None))
            .ToArray();

        try
        {
            _ = await Task.WhenAll(tasks);
        }
        catch
        {
            // The exception is unimportant
        }

        IEnumerable<Task<object>> fails = tasks.Where(task => task.IsFaulted);
        IEnumerable<Task<object>> others = tasks.Except(fails);

        Assert.Equal(ExpectedSuccesses, successes);
        Assert.Equal(failures, fails.Count());
        Assert.All(others, task => Assert.Same(task.Result, expected));
    }

    [Fact]
    public async Task GivenAnExceptionThenTheExceptionIsThrownAsync()
    {
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        var initializer = new Initializer<object>(Initializer);

        _ = await Assert.ThrowsAsync<NotImplementedException>(() => initializer.InitializeAsync(CancellationToken.None));
    }

    [Fact]
    public async Task GivenAFailureToInitializeThenAnInvalidOperationExceptionIsThrown()
    {
        static Task<object> Initializer(CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(default!);
        }

        var initializer = new Initializer<object>(Initializer);

        _ = await Assert.ThrowsAsync<InvalidOperationException>(() => initializer.InitializeAsync(CancellationToken.None));
    }
}