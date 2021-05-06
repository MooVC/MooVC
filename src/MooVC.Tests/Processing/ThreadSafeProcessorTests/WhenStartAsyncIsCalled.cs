namespace MooVC.Processing.ThreadSafeProcessorTests
{
    using System;
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
        public async void GivenAStoppedProcessorWhenStartCannotSucceedThenTheProcessorStopsAsync()
        {
            byte invocations = 0;
            const byte ExpectedInvocations = 1;

            static void Start()
            {
                throw new Exception();
            }

            void Stop()
            {
                invocations++;
            }

            var processor = new TestProcessor(start: Start, stop: Stop);

            _ = await Assert.ThrowsAsync<Exception>(() => processor.StartAsync(CancellationToken.None));

            Assert.Equal(ProcessorState.Stopped, processor.State);
            Assert.Equal(ExpectedInvocations, invocations);
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