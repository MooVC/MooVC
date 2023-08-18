namespace MooVC.Threading.CoordinatorTests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using Xunit;

public sealed class WhenApplyAsyncIsCalled
    : IDisposable
{
    private readonly ICoordinator<string> coordinator;

    public WhenApplyAsyncIsCalled()
    {
        coordinator = new Coordinator<string>();
    }

    public void Dispose()
    {
        coordinator.Dispose();
    }

    [Fact]
    public async Task GivenAnEmptyContextThenAnArgumentNullExceptionIsThrownAsync()
    {
        // Arrange
        string? context = default;

        // Act
        Func<Task> act = async () => await coordinator.ApplyAsync(context!, CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ArgumentNullException>()
            .WithParameterName(nameof(context));
    }

    [Fact]
    public async Task GivenADisposedCoordinatorThenAnObjectDisposedExceptionIsThrownAsync()
    {
        // Arrange
        coordinator.Dispose();

        // Act
        Func<Task> act = async () => await coordinator.ApplyAsync("N/A", CancellationToken.None);

        // Assert
        _ = await act.Should().ThrowAsync<ObjectDisposedException>();
    }

    [Fact]
    public async Task GivenMultipleThreadsNoConcurrencyExceptionsAreThrownAsync()
    {
        // Arrange
        const int ExpectedCount = 5;
        int counter = 0;
        string context = "Test";

        Task[] tasks = CreateTasks(
            async () =>
            {
                ICoordinationContext<string> coordination = await coordinator
                    .ApplyAsync(context, CancellationToken.None)
                    .ConfigureAwait(false);

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
    public async Task GivenATimedOutRequestThenATimeoutExceptionIsThrownAsync()
    {
        // Arrange
        string context = "Test";
        using var semaphore = new SemaphoreSlim(0, 1);

        // Act
        _ = Task.Run(async () =>
        {
            using (await coordinator.ApplyAsync(context, CancellationToken.None))
            {
                _ = semaphore.Release();
                await Task.Delay(TimeSpan.FromSeconds(10));
            }
        });

        await semaphore.WaitAsync();

        // Act
        Func<Task> act = async () => await coordinator.ApplyAsync(context, CancellationToken.None, TimeSpan.FromMilliseconds(250));

        // Assert
        _ = await act.Should().ThrowAsync<TimeoutException>();
    }

    [Fact]
    public async Task GivenACoordinatableContextThenItsKeyIsUsedForCoordinationAsync()
    {
        // Arrange
        string expected = Guid.NewGuid().ToString();
        ITestCoordinatable context = Substitute.For<ITestCoordinatable>();
        var coordinator = new Coordinator<ITestCoordinatable>();

        _ = context.GetKey().Returns(expected);

        // Act
        ICoordinationContext<ITestCoordinatable> coordination = await coordinator
            .ApplyAsync(context, CancellationToken.None)
            .ConfigureAwait(false);

        // Assert
        using (coordination)
        {
            _ = context.Received(1).GetKey();
        }
    }

    [Fact]
    public async Task GivenANonCoordinatableContextThenItsStringIsUsedForCoordinationAsync()
    {
        // Arrange
        object context = Substitute.For<object>();
        var coordinator = new Coordinator<object>();

        // Act
        ICoordinationContext<object> coordination = await coordinator
            .ApplyAsync(context, CancellationToken.None)
            .ConfigureAwait(false);

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

        return tasks.ToArray();
    }
}