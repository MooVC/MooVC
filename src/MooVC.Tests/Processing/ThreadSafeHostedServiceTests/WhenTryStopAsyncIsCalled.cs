namespace MooVC.Processing.ThreadSafeHostedServiceTests;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Moq;
using Xunit;

public sealed class WhenTryStopAsyncIsCalled
{
    private readonly ThreadSafeHostedService processor;
    private readonly Mock<IHostedService> service;

    public WhenTryStopAsyncIsCalled()
    {
        service = new Mock<IHostedService>();
        processor = new ThreadSafeHostedService(new[] { service.Object });
    }

    [Fact]
    public async void GivenAStartedProcessorThenAPositiveResponseIsReturnedAsync()
    {
        await processor.StartAsync(CancellationToken.None);

        Assert.Equal(ProcessorState.Started, processor.State);

        bool wasStopped = await processor.TryStopAsync(CancellationToken.None);

        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);
        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Once);

        Assert.True(wasStopped);
    }

    [Fact]
    public async void GivenAStoppedProcessorThenANegativeResponseIsReturnedAsync()
    {
        bool wasStopped = await processor.TryStopAsync(CancellationToken.None);

        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Never);

        Assert.False(wasStopped);
    }

    [Fact]
    public async void GivenAStartedProcessorWhenMultipleConsumersAreInvoledThenAPositiveResponseIsReturnedToOnlyOneAsync()
    {
        const int ExpectedCount = 1;

        await processor.StartAsync(CancellationToken.None);

        service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);

        int counter = 0;

        IEnumerable<Task> tasks = Enumerable
            .Range(0, 20)
            .Select(_ => Task.Run(async () =>
            {
                bool wasStarted = await processor.TryStopAsync(CancellationToken.None);

                if (wasStarted)
                {
                    counter++;
                }
            }))
            .ToArray();

        await Task.WhenAll(tasks);

        service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Once);

        Assert.Equal(ExpectedCount, counter);
    }
}