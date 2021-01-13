namespace MooVC.Processing.ThreadSafeProcessorTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class WhenTryStopAsyncIsCalled
    {
        [Fact]
        public async void GivenAStartedProcessorThenAPositiveResponseIsReturnedAsync()
        {
            var processor = new TestProcessor();

            await processor.StartAsync(CancellationToken.None);

            Assert.Equal(ProcessorState.Started, processor.State);

            bool wasStopped = await processor.TryStopAsync(CancellationToken.None);

            Assert.True(wasStopped);
        }

        [Fact]
        public async void GivenAStoppedProcessorThenANegativeResponseIsReturnedAsync()
        {
            var processor = new TestProcessor();

            bool wasStopped = await processor.TryStopAsync(CancellationToken.None);

            Assert.False(wasStopped);
        }

        [Fact]
        public async void GivenAStartedProcessorWhenMultipleConsumersAreInvoledThenAPositiveResponseIsReturnedToOnlyOneAsync()
        {
            const int ExpectedCount = 1;

            var processor = new TestProcessor();

            await processor.StartAsync(CancellationToken.None);

            int counter = 0;

            IEnumerable<Task> tasks = Enumerable
                .Range(0, 20)
                .Select(_ => Task.Run(async () =>
                {
                    bool wasStarted = await processor.TryStopAsync(CancellationToken.None);

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