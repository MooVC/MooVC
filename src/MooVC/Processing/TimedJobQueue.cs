namespace MooVC.Processing
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using MooVC.Collections.Generic;
    using static MooVC.Ensure;
    using static Resources;

    public abstract class TimedJobQueue<T>
        : IDisposable
    {
        private readonly ConcurrentQueue<T> queue = new ConcurrentQueue<T>();
        private readonly TimedProcessor timer;
        private bool isDisposed = false;

        protected TimedJobQueue(TimedProcessor timer)
        {
            ArgumentNotNull(timer, nameof(timer), JobQueueTimerRequired);

            this.timer = timer;
            this.timer.Triggered += Timer_Triggered;
        }

        public bool HasJobsPending => queue.Count > 0;

        public void Enqueue(T job)
        {
            queue.Enqueue(job);

            StartTimer();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    timer.Triggered -= Timer_Triggered;

                    timer.Dispose();
                }

                isDisposed = true;
            }
        }

        protected abstract void OnFailureEncountered(Exception failure);

        protected abstract IEnumerable<T> Process(IEnumerable<T> jobs);

        private void StartTimer()
        {
            if (HasJobsPending)
            {
                _ = timer.TryStart();
            }
        }

        private void Timer_Triggered(object sender, EventArgs e)
        {
            var pending = new List<T>();

            try
            {
                try
                {
                    _ = timer.TryStop();

                    while (queue.TryDequeue(out T @event))
                    {
                        pending.Add(@event);
                    }

                    Process(pending).ForEach(queue.Enqueue);
                }
                finally
                {
                    StartTimer();
                }
            }
            catch (Exception failure)
            {
                OnFailureEncountered(failure);
            }
        }
    }
}