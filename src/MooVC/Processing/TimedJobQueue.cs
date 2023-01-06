namespace MooVC.Processing;

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

/// <summary>
/// Represents a base implementation for a long running thread-safe process that manages a queue of tasks to be performed on a timed basis.
/// </summary>
/// <typeparam name="T">The type of job to be processed.</typeparam>
public abstract class TimedJobQueue<T>
    : IDisposable,
      IEmitDiagnostics
{
    private readonly ConcurrentQueue<T> queue = new();
    private readonly TimedProcessor timer;
    private bool isDisposed;

    /// <summary>
    /// Facilitates initialization of a <see cref="TimedJobQueue{T}"/> using the <paramref name="timer"/> to determine when processing should occur.
    /// </summary>
    /// <param name="timer">The timer that determines when jobs in the queue should be processed.</param>
    /// <remarks>The <paramref name="timer"/> will only be started when a job is enqueued and will be stopped when no jobs remain.</remarks>
    protected TimedJobQueue(TimedProcessor timer)
    {
        this.timer = IsNotNull(timer, message: JobQueueTimerRequired);

        this.timer.Triggered += Timer_Triggered;
    }

    /// <summary>
    /// An event that is raised when an diagnostic related occurance is encountered.
    /// </summary>
    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    /// <summary>
    /// Gets a value indicating whether any jobs are queued.
    /// </summary>
    /// <value>
    /// <c>true</c> if there are jobs present in the queue, otherwise <c>false</c>.
    /// </value>
    public bool HasJobsPending => queue.Any();

    /// <summary>
    /// Adds the specified <paramref name="job"/> to the queue.
    /// </summary>
    /// <param name="job">The job to add to the queue for deferred processing.</param>
    public void Enqueue(T job)
    {
        queue.Enqueue(job);

        _ = StartTimerAsync();
    }

    /// <summary>
    /// Releases all resources used by this instance.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases all resources used by this instance.
    /// </summary>
    /// <param name="isDisposing">
    /// <c>true</c> if this method was called directly or indirectly by a user's code;
    /// <c>false</c> if this method was called by the runtime from inside the finalizer.
    /// </param>
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

    /// <summary>
    /// Emits a diagnostic event.
    /// </summary>
    /// <param name="level">The perceived <see cref="Level" /> of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="cause">The <see cref="Exception" /> that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="message">A friendly description of the event, if any.</param>
    protected virtual void OnDiagnosticsEmitted(Level level, Exception? cause = default, string? message = default)
    {
        _ = DiagnosticsEmitted.PassiveInvokeAsync(this, new DiagnosticsEmittedAsyncEventArgs(cause: cause, level: level, message: message));
    }

    /// <summary>
    /// Supports the synchronous processing of the jobs specified in <paramref name="jobs"/>.
    /// </summary>
    /// <param name="jobs">A list of one or more jobs to be processed.</param>
    /// <typeparam name="T">The type of job to be processed.</typeparam>
    /// <returns>A list of jobs to be returned to the queue.</returns>
    protected abstract IEnumerable<T> Process(IEnumerable<T> jobs);

    /// <summary>
    /// Asynchronous prepares the list of jobs to be processed.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
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

                while (queue.TryDequeue(out T? @event))
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
            OnDiagnosticsEmitted(Level.Error, cause: failure, message: TimedJobQueueProcessQueueAsyncFailure);
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