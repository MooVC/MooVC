namespace MooVC.Processing;

using System;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Diagnostics;
using static System.String;
using static MooVC.Processing.Resources;

public class TimedProcessor
    : ThreadSafeProcessor,
      IDisposable
{
    private readonly TimeSpan delay;
    private readonly TimeSpan initial;
    private readonly Lazy<Timer> timer;
    private bool isDisposed;

    public TimedProcessor(TimeSpan delay, IDiagnosticsProxy? diagnostics = default, TimeSpan? initial = default)
        : base(diagnostics: diagnostics)
    {
        this.initial = initial ?? delay;
        this.delay = delay;
        timer = new Lazy<Timer>(() => new Timer(TimerCallbackAsync));
    }

    public event EventHandler? Triggered;

    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
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

    protected override Task PerformStartAsync(CancellationToken cancellationToken)
    {
        _ = timer.Value.Change(initial, delay);

        return Task.CompletedTask;
    }

    protected override Task PerformStopAsync(CancellationToken cancellationToken)
    {
        _ = timer.Value.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);

        return Task.CompletedTask;
    }

    protected virtual Task PerformTimerCallbackAsync()
    {
        return Task.CompletedTask;
    }

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