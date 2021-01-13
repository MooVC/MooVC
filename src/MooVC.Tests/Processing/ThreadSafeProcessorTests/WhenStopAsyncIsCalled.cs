namespace MooVC.Processing.ThreadSafeProcessorTests
{
    using System.Threading;
    using Xunit;

    public sealed class WhenStopAsyncIsCalled
    {
        [Fact]
        public async void GivenAStartedProcessorThenTheProcessorStopsAsync()
        {
            var processor = new TestProcessor();

            await processor.StartAsync(CancellationToken.None);

            Assert.Equal(ProcessorState.Started, processor.State);

            await processor.StopAsync(CancellationToken.None);

            Assert.Equal(ProcessorState.Stopped, processor.State);
        }

        [Fact]
        public async void GivenAStoppedProcessorThenAStopOperationInvalidExceptionIsThrownAsync()
        {
            var processor = new TestProcessor();

            _ = await Assert.ThrowsAsync<StopOperationInvalidException>(
                () => processor.StopAsync(CancellationToken.None));
        }
    }
}