namespace MooVC.Threading.CoordinatorTests;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        _ = await Assert.ThrowsAsync<ArgumentNullException>(() => coordinator.ApplyAsync(default!, CancellationToken.None));
    }

    [Fact]
    public async Task GivenADisposedCoordinatorThenAnObjectDisposedExceptionIsThrownAsync()
    {
        coordinator.Dispose();

        _ = await Assert.ThrowsAsync<ObjectDisposedException>(() => coordinator.ApplyAsync(default!, CancellationToken.None));
    }

    [Fact]
    public async Task GivenMultipleThreadsNoConcurrencyExceptionsAreThrownAsync()
    {
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

        await Task.WhenAll(tasks);

        Assert.Equal(ExpectedCount, counter);
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