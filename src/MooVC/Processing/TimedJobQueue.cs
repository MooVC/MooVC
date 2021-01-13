namespace MooVC.Processing
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MooVC.Collections.Generic;
    using static MooVC.Ensure;
    using static MooVC.Processing.Resources;

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

        public bool HasJobsPending => queue.Any();

        public void Enqueue(T job)
        {
            queue.Enqueue(job);

            _ = StartTimerAsync();
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

        private async Task StartTimerAsync()
        {
            if (HasJobsPending)
            {
                _ = await timer
                    .TryStartAsync(CancellationToken.None)
                    .ConfigureAwait(false);
            }
        }

        private async void Timer_Triggered(object? sender, EventArgs e)
        {
            var pending = new List<T>();

            try
            {
                try
                {
                    _ = await timer
                        .TryStopAsync(CancellationToken.None)
                        .ConfigureAwait(false);

                    while (queue.TryDequeue(out T @event))
                    {
                        pending.Add(@event);
                    }

                    Process(pending).ForEach(queue.Enqueue);
                }
                finally
                {
                    await StartTimerAsync()
                        .ConfigureAwait(false);
                }
            }
            catch (Exception failure)
            {
                OnFailureEncountered(failure);
            }
        }
    }
}