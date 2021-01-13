namespace MooVC.Processing.ThreadSafeProcessorTests
{
    using System.Threading;
    using Xunit;

    public sealed class WhenStartAsyncIsCalled
    {
        [Fact]
        public async void GivenAStoppedProcessorThenTheProcessorStartsAsync()
        {
            var processor = new TestProcessor();

            await processor.StartAsync(CancellationToken.None);

            Assert.Equal(ProcessorState.Started, processor.State);
        }

        [Fact]
        public async void GivenAStartedProcessorThenAStartOperationInvalidExceptionIsThrownAsync()
        {
            var processor = new TestProcessor();

            await processor.StartAsync(CancellationToken.None);

            _ = await Assert.ThrowsAsync<StartOperationInvalidException>(
                () => processor.StartAsync(CancellationToken.None));
        }
    }
}