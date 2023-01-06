namespace MooVC.Processing;

using System;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Diagnostics;
using static System.String;
using static MooVC.Processing.Resources;

/// <summary>
/// Encapsulates the functionality of <see cref="Timer"/> within the <see cref="IProcessor"/> interface.
/// </summary>
public class TimedProcessor
    : ThreadSafeProcessor,
      IDisposable
{
    private readonly TimeSpan delay;
    private readonly TimeSpan initial;
    private readonly Lazy<Timer> timer;
    private bool isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="TimedProcessor"/> class.
    /// </summary>
    /// <param name="delay">The delay between timer callbacks.</param>
    /// <param name="diagnostics">
    /// The proxy that determines if diagnostics are to be emitted, with the default configuration used if not provided.
    /// </param>
    /// <param name="initial">
    /// The initial delay before the first timer callback, or <c>null</c> to use the same value as <paramref name="delay"/>.
    /// </param>
    public TimedProcessor(TimeSpan delay, IDiagnosticsProxy? diagnostics = default, TimeSpan? initial = default)
        : base(diagnostics: diagnostics)
    {
        this.initial = initial ?? delay;
        this.delay = delay;
        timer = new Lazy<Timer>(() => new Timer(TimerCallbackAsync));
    }

    /// <summary>
    /// An event that is raised when the time associated with the timer has elapsed.
    /// </summary>
    public event EventHandler? Triggered;

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
            if (isDisposing && timer.IsValueCreated)
            {
                timer.Value.Dispose();
            }

            isDisposed = true;
        }
    }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected override Task PerformStartAsync(CancellationToken cancellationToken)
    {
        _ = timer.Value.Change(initial, delay);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected override Task PerformStopAsync(CancellationToken cancellationToken)
    {
        _ = timer.Value.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Facilitates the asynchronously invocation of work to be done when the timer triggers.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual Task PerformTimerCallbackAsync()
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Asynchronously performs the work to be done when the timer triggers.
    /// </summary>
    private async void TimerCallbackAsync(object? state)
    {
        try
        {
            try
            {
                Triggered?.Invoke(this, EventArgs.Empty);
            }
            finally
            {
                await PerformTimerCallbackAsync()
                    .ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            await Diagnostics
                .EmitAsync(
                    cause: ex,
                    impact: Impact.Recoverable,
                    message: Format(TimedProcessorTimerCallbackFailure, GetType().Name))
                .ConfigureAwait(false);
        }
    }
}