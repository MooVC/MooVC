namespace MooVC.Processing
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class TestProcessor
        : ThreadSafeProcessor
    {
        private readonly Action? start;
        private readonly Action? stop;

        public TestProcessor(Action? start = default, Action? stop = default)
        {
            this.start = start;
            this.stop = stop;
        }

        protected override async Task PerformStartAsync(CancellationToken cancellationToken)
        {
            start?.Invoke();

            await Task.CompletedTask;
        }

        protected override async Task PerformStopAsync(CancellationToken cancellationToken)
        {
            stop?.Invoke();

            await Task.CompletedTask;
        }
    }
}