namespace MooVC.Processing
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using MooVC.Collections.Generic;
    using MooVC.Diagnostics;
    using static MooVC.Ensure;
    using static MooVC.Processing.Resources;

    public abstract class TimedJobQueue<T>
        : IDisposable,
          IEmitDiagnostics
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

        public event DiagnosticsEmittedEventHandler? DiagnosticsEmitted;

        public bool HasJobsPending => queue.Any();

        public void Enqueue(T job)
        {
            queue.Enqueue(job);

            _ = StartTimerAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
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

        protected virtual void OnDiagnosticsEmitted(
            Level level,
            Exception? cause = default,
            string? message = default)
        {
            DiagnosticsEmitted?.Invoke(
                this,
                new DiagnosticsEmittedEventArgs(
                    cause: cause,
                    level: level,
                    message: message));
        }

        protected abstract IEnumerable<T> Process(IEnumerable<T> jobs);

        private async Task ProcessQueueAsync()
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
                OnDiagnosticsEmitted(
                    Level.Error,
                    cause: failure,
                    message: TimedJobQueueProcessQueueAsyncFailure);
            }
        }

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
            await ProcessQueueAsync()
                .ConfigureAwait(false);
        }
    }
}