namespace MooVC.Processing.ThreadSafeProcessorTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenTryStartAsyncIsCalled
    {
        [Fact]
        public async void GivenAStoppedProcessorThenAPositiveResponseIsReturnedAsync()
        {
            var processor = new TestProcessor();
            bool wasStarted = await processor.TryStartAsync(CancellationToken.None);

            Assert.True(wasStarted);
        }

        [Fact]
        public async void GivenAStartedProcessorThenANegativeResponseIsReturnedAsync()
        {
            var processor = new TestProcessor();

            await processor.StartAsync(CancellationToken.None);

            bool wasStarted = await processor.TryStartAsync(CancellationToken.None);

            Assert.False(wasStarted);
        }

        [Fact]
        public async void GivenAStoppedProcessorWhenMultipleConsumersAreInvoledThenAPositiveResponseIsReturnedToOnlyOneAsync()
        {
            const int ExpectedCount = 1;

            var processor = new TestProcessor();

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

            Assert.Equal(ExpectedCount, counter);
        }
    }
}