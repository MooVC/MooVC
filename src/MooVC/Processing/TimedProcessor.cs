namespace MooVC.Processing
{
    using System;
    using System.Threading;
    using static System.String;
    using static Resources;

    public class TimedProcessor
        : Processor,
          IDisposable
    {
        private readonly TimeSpan delay;
        private readonly TimeSpan initial;
        private readonly Lazy<Timer> timer;
        private bool isDisposed;

        public TimedProcessor(TimeSpan delay, TimeSpan? initial = default)
        {
            this.initial = initial ?? delay;
            this.delay = delay;
            timer = new Lazy<Timer>(() => new Timer(TimerCallback));
        }

        public event EventHandler? Triggered;

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

        protected virtual void PerformTimerCallback()
        {
        }

        private void TimerCallback(object state)
        {
            try
            {
                try
                {
                    Triggered?.Invoke(this, EventArgs.Empty);
                }
                finally
                {
                    PerformTimerCallback();
                }
            }
            catch (Exception ex)
            {
                OnFailureEncountered(Format(TimedProcessorCallbackHandlingFailure, GetType().Name), ex);
            }
        }
    }
}
