namespace MooVC.Threading.CoordinatorTests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
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