namespace MooVC.Processing.ThreadSafeHostedServiceTests
{
    using System.Threading;
    using Microsoft.Extensions.Hosting;
    using Moq;
    using Xunit;

    public sealed class WhenStopAsyncIsCalled
    {
        private readonly ThreadSafeHostedService processor;
        private readonly Mock<IHostedService> service;

        public WhenStopAsyncIsCalled()
        {
            service = new Mock<IHostedService>();
            processor = new ThreadSafeHostedService(service.Object);
        }

        [Fact]
        public async void GivenAStartedProcessorThenTheProcessorStopsAsync()
        {
            await processor.StartAsync(CancellationToken.None);

            Assert.Equal(ProcessorState.Started, processor.State);

            await processor.StopAsync(CancellationToken.None);

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);
            service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.Equal(ProcessorState.Stopped, processor.State);
        }

        [Fact]
        public async void GivenAStoppedProcessorThenAStopOperationInvalidExceptionIsThrownAsync()
        {
            _ = await Assert.ThrowsAsync<StopOperationInvalidException>(
                () => processor.StopAsync(CancellationToken.None));

            service.Verify(host => host.StopAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
