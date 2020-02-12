namespace MooVC.Processing.ProcessorTests
{
    using Xunit;

    public sealed class WhenStopIsCalled
    {
        [Fact]
        public void GivenAStartedProcessorThenTheProcessorStops()
        {
            var processor = new TestProcessor();

            processor.Start();

            Assert.Equal(ProcessorState.Started, processor.State);

            processor.Stop();

            Assert.Equal(ProcessorState.Stopped, processor.State);
        }

        [Fact]
        public void GivenAStoppedProcessorThenAStopOperationInvalidExceptionIsThrown()
        {
            var processor = new TestProcessor();

            _ = Assert.Throws<StopOperationInvalidException>(() => processor.Stop());
        }
    }
}
