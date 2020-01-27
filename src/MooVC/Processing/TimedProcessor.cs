namespace MooVC.Processing
{
    using System;
    using System.Threading;
    using static System.String;
    using static Resources;

    public abstract class TimedProcessor
        : Processor,
          IDisposable
    {
        private readonly TimeSpan delay;
        private readonly TimeSpan initial;
        private readonly Lazy<Timer> timer;
        private bool isDisposed;

        protected TimedProcessor(TimeSpan delay, TimeSpan? initial = default)
        {
            this.initial = initial ?? delay;
            this.delay = delay;
            timer = new Lazy<Timer>(() => new Timer(TimerCallback));
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing && timer.IsValueCreated)
                {
                    timer.Value.Dispose();
                }

                isDisposed = true;
            }
        }

        protected override bool PerformStart()
        {
            _ = timer.Value.Change(initial, delay);

            return false;
        }

        protected override bool PerformStop()
        {
            _ = timer.Value.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);

            return false;
        }

        protected abstract void PerformTimerCallback();

        private void TimerCallback(object state)
        {
            try
            {
                PerformTimerCallback();
            }
            catch (Exception ex)
            {
                EmitFailure(Format(TimedProcessorCallbackHandlingFailure, GetType().Name), ex);
            }
        }
    }
}
