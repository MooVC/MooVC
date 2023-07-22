namespace MooVC.Threading.InitializerTests;

using System;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

public sealed class WhenInitializeAsyncIsCalled
{
    [Fact]
    public async Task GivenAnInitializerThenTheInitializerIsOnlyCalledOnceAndTheInstanceIsAlwaysTheSameAsync()
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
        object? first = await initializer.InitializeAsync(CancellationToken.None);
        object? second = await initializer.InitializeAsync(CancellationToken.None);
        object? third = await initializer.InitializeAsync(CancellationToken.None);

        // Assert
        _ = invocations.Should().Be(ExpectedInvocations);
        _ = first.Should().NotBeNull();
        _ = first.Should().Be(second);
        _ = first.Should().Be(third);
        _ = second.Should().Be(third);
    }

    [Fact]
    public async Task GivenAnInitializerWhenContinueOnCapturedContextIsFalseThenTheInitializerIsOnlyCalledOnceAsync()
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
        _ = await initializer.InitializeAsync(CancellationToken.None).ConfigureAwait(false);
        _ = await initializer.InitializeAsync(CancellationToken.None).ConfigureAwait(false);
        _ = await initializer.InitializeAsync(CancellationToken.None).ConfigureAwait(false);

        // Assert
        _ = invocations.Should().Be(ExpectedInvocations);
    }

    // Other tests go here...

    // Additional test cases
    [Fact]
    public async Task GivenAnInitializerWithDelayThenTheInitializerIsStillCalledOnlyOnceAsync()
    {
        // Arrange
        const int ExpectedInvocations = 1;
        int invocations = 0;

        async Task<object> Initializer(CancellationToken cancellationToken)
        {
            invocations++;
            await Task.Delay(500);  // Simulate some delay
            return new object();
        }

        var initializer = new Initializer<object>(Initializer);

        // Act
        Task<object>[] tasks = Enumerable.Range(0, 10)
            .Select(_ => initializer.InitializeAsync(CancellationToken.None))
            .ToArray();

        _ = await Task.WhenAll(tasks);

        // Assert
        _ = invocations.Should().Be(ExpectedInvocations);
        _ = tasks.Select(t => t.Result).Distinct().Should().HaveCount(1);
    }
}