namespace MooVC.Processing.ProcessorTests
{
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenTryStartIsCalled
    {
        [Fact]
        public void GivenAStoppedProcessorThenAPositiveResponseIsReturned()
        {
            var processor = new TestProcessor();
            bool wasStarted = processor.TryStart();

            Assert.True(wasStarted);
        }

        [Fact]
        public void GivenAStartedProcessorThenANegativeResponseIsReturned()
        {
            var processor = new TestProcessor();

            processor.Start();

            bool wasStarted = processor.TryStart();

            Assert.False(wasStarted);
        }

        [Fact]
        public void GivenAStoppedProcessorWhenMultipleConsumersAreInvoledThenAPositiveResponseIsReturnedToOnlyOne()
        {
            const int ExpectedCount = 1;

            var processor = new TestProcessor();

            int counter = 0;

            _ = Parallel.For(0, 20, _ =>
            {
                if (processor.TryStart())
                {
                    counter++;
                }
            });

            Assert.Equal(ExpectedCount, counter);
        }
    }
}
