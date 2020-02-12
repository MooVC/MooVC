namespace MooVC.Processing.ProcessorTests
{
    using Xunit;

    public sealed class WhenStartIsCalled
    {
        [Fact]
        public void GivenAStoppedProcessorThenTheProcessorStarts()
        {
            var processor = new TestProcessor();

            processor.Start();

            Assert.Equal(ProcessorState.Started, processor.State);
        }

        [Fact]
        public void GivenAStartedProcessorThenAStartOperationInvalidExceptionIsThrown()
        {
            var processor = new TestProcessor();

            processor.Start();

            _ = Assert.Throws<StartOperationInvalidException>(() => processor.Start());
        }
    }
}
