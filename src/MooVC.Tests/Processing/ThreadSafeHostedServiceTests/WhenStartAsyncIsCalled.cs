namespace MooVC.Processing.ThreadSafeHostedServiceTests
{
    using System.Threading;
    using Microsoft.Extensions.Hosting;
    using Moq;
    using Xunit;

    public sealed class WhenStartAsyncIsCalled
    {
        private readonly ThreadSafeHostedService processor;
        private readonly Mock<IHostedService> service;

        public WhenStartAsyncIsCalled()
        {
            service = new Mock<IHostedService>();
            processor = new ThreadSafeHostedService(new[] { service.Object });
        }

        [Fact]
        public async void GivenAStoppedProcessorThenTheProcessorStartsAsync()
        {
            await processor.StartAsync(CancellationToken.None);

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.Equal(ProcessorState.Started, processor.State);
        }

        [Fact]
        public async void GivenAStartedProcessorThenAStartOperationInvalidExceptionIsThrownAsync()
        {
            await processor.StartAsync(CancellationToken.None);

            _ = await Assert.ThrowsAsync<StartOperationInvalidException>(
                () => processor.StartAsync(CancellationToken.None));

            service.Verify(host => host.StartAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}