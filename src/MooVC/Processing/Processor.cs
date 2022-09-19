namespace MooVC.Processing;

using System;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Diagnostics;
using static MooVC.Processing.Resources;

public abstract class Processor
    : IProcessor,
      IEmitDiagnostics
{
    private ProcessorState state = ProcessorState.Stopped;

    protected Processor(IDiagnosticsProxy? diagnostics = default)
    {
        Diagnostics = new DiagnosticsRelay(this, diagnostics: diagnostics);
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted
    {
        add => Diagnostics.DiagnosticsEmitted += value;
        remove => Diagnostics.DiagnosticsEmitted -= value;
    }

    public event ProcessorStateChangedAsyncEventHandler? ProcessStateChanged;

    public ProcessorState State
    {
        get => state;
        private set
        {
            if (state != value)
            {
                state = value;

                _ = OnProcessingStateChangedAsync(value);
            }
        }
    }

    protected IDiagnosticsRelay Diagnostics { get; }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (CanStart())
        {
            State = ProcessorState.Starting;

            try
            {
                await PerformStartAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                State = ProcessorState.Unknown;

                await PerformStopAsync(cancellationToken)
                    .ConfigureAwait(false);

                State = ProcessorState.Stopped;

                throw;
            }

            State = ProcessorState.Started;
        }
        else
        {
            throw new StartOperationInvalidException(State);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (CanStop())
        {
            State = ProcessorState.Stopping;

            await PerformStopAsync(cancellationToken)
                .ConfigureAwait(false);

            State = ProcessorState.Stopped;
        }
        else
        {
            throw new StopOperationInvalidException(State);
        }
    }

    public async Task<bool> TryStartAsync(CancellationToken cancellationToken)
    {
        try
        {
            await StartAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception ex)
        {
            Impact impact = ex is StartOperationInvalidException
                ? Impact.None
                : Impact.Recoverable;

            await Diagnostics
                .EmitAsync(cancellationToken: cancellationToken, cause: ex, impact: impact, message: ProcessorTryStartFailure)
                .ConfigureAwait(false);
        }

        return false;
    }

    public async Task<bool> TryStopAsync(CancellationToken cancellationToken)
    {
        try
        {
            await StopAsync(cancellationToken)
                .ConfigureAwait(false);

            return true;
        }
        catch (Exception ex)
        {
            Impact impact = ex is StopOperationInvalidException
                ? Impact.None
                : Impact.Recoverable;

            await Diagnostics
                .EmitAsync(cancellationToken: cancellationToken, cause: ex, impact: impact, message: ProcessorTryStopFailure)
                .ConfigureAwait(false);
        }

        return false;
    }

    protected virtual bool CanStart()
    {
        return State == ProcessorState.Stopped;
    }

    protected virtual bool CanStop()
    {
        return State == ProcessorState.Started;
    }

    protected virtual Task OnProcessingStateChangedAsync(
        ProcessorState state,
        CancellationToken? cancellationToken = default)
    {
        return ProcessStateChanged.PassiveInvokeAsync(
            this,
            new ProcessorStateChangedAsyncEventArgs(state),
            onFailure: failure => Diagnostics.EmitAsync(
                cancellationToken: cancellationToken,
                cause: failure,
                impact: Impact.None,
                message: ProcessorOnProcessingStateChangedAsyncFailure));
    }

    protected abstract Task PerformStartAsync(CancellationToken cancellationToken);

    protected abstract Task PerformStopAsync(CancellationToken cancellationToken);
}