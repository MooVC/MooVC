namespace MooVC.Processing.ThreadSafeHostedServiceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Hosting;
    using Moq;
    using Xunit;

    public sealed class WhenTryStartAsyncIsCalled
    {
        private readonly ThreadSafeHostedService processor;
        private readonly Mock<IHostedService> service;

        public WhenTryStartAsyncIsCalled()
        {
            service = new Mock<IHostedService>();
            processor = new ThreadSafeHostedService(new[] { service.Object });
        }

        [Fact]
        public async void GivenAStoppedProcessorThenAPositiveResponseIsReturnedAsync()
        {
            bool wasStarted = await processor.TryStartAsync(CancellationToken.None);

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.True(wasStarted);
        }

        [Fact]
        public async void GivenAStartedProcessorThenANegativeResponseIsReturnedAsync()
        {
            await processor.StartAsync(CancellationToken.None);

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);

            bool wasStarted = await processor.TryStartAsync(CancellationToken.None);

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.False(wasStarted);
        }

        [Fact]
        public async void GivenAStoppedProcessorWhenMultipleConsumersAreInvoledThenAPositiveResponseIsReturnedToOnlyOneAsync()
        {
            const int ExpectedCount = 1;

            int counter = 0;

            IEnumerable<Task> tasks = Enumerable
                .Range(0, 20)
                .Select(_ => Task.Run(async () =>
                {
                    bool wasStarted = await processor.TryStartAsync(CancellationToken.None);

                    if (wasStarted)
                    {
                        counter++;
                    }
                }))
                .ToArray();

            await Task.WhenAll(tasks);

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.Equal(ExpectedCount, counter);
        }
    }
}