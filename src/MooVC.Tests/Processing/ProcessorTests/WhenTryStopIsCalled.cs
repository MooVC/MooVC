namespace MooVC.Processing.ProcessorTests
{
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenTryStopIsCalled
    {
        [Fact]
        public void GivenAStartedProcessorThenAPositiveResponseIsReturned()
        {
            var processor = new TestProcessor();

            processor.Start();

            Assert.Equal(ProcessorState.Started, processor.State);

            bool wasStopped = processor.TryStop();

            Assert.True(wasStopped);
        }

        [Fact]
        public void GivenAStoppedProcessorThenANegativeResponseIsReturned()
        {
            var processor = new TestProcessor();

            bool wasStopped = processor.TryStop();

            Assert.False(wasStopped);
        }

        [Fact]
        public void GivenAStartedProcessorWhenMultipleConsumersAreInvoledThenAPositiveResponseIsReturnedToOnlyOne()
        {
            const int ExpectedCount = 1;

            var processor = new TestProcessor();

            processor.Start();

            int counter = 0;

            _ = Parallel.For(0, 20, _ =>
              {
                  if (processor.TryStop())
                  {
                      counter++;
                  }
              });

            Assert.Equal(ExpectedCount, counter);
        }
    }
}
