namespace MooVC.Processing;

using System;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Diagnostics;
using static MooVC.Processing.Resources;

/// <summary>
/// Represents a base implementation for a long running process.
/// </summary>
public abstract class Processor
    : IProcessor,
      IEmitDiagnostics
{
    private ProcessorState state = ProcessorState.Stopped;

    /// <summary>
    /// Facilitates the Initialization of new instance based on the <see cref="Processor"/> class.
    /// </summary>
    /// <param name="diagnostics">
    /// The proxy that determines if diagnostics are to be emitted, with the default configuration used if not provided.
    /// </param>
    protected Processor(IDiagnosticsProxy? diagnostics = default)
    {
        Diagnostics = new DiagnosticsRelay(this, diagnostics: diagnostics);
    }

    /// <summary>
    /// An event that is raised when an diagnostic related occurance is encountered.
    /// </summary>
    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted
    {
        add => Diagnostics.DiagnosticsEmitted += value;
        remove => Diagnostics.DiagnosticsEmitted -= value;
    }

    /// <summary>
    /// An event that is raised when the state of the processor changes.
    /// </summary>
    public event ProcessorStateChangedAsyncEventHandler? StateChanged;

    /// <summary>
    /// Gets the current state of the processor.
    /// </summary>
    /// <value>
    /// The current state of the processor.
    /// </value>
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

    /// <summary>
    /// Gets the instance of <see cref="DiagnosticsRelay"/> that is capable of emiting diagnostics events on behalf of the processor.
    /// </summary>
    /// <value>
    /// The instance of <see cref="DiagnosticsRelay"/> that is capable of emiting diagnostics events on behalf of the processor.
    /// </value>
    protected IDiagnosticsRelay Diagnostics { get; }

    /// <summary>
    /// Tries to start the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// The result of the task is a boolean value indicating whether the attempt to start the processor was successful.
    /// </returns>
    /// <exception cref="StartOperationInvalidException">
    /// The processor is not in a startable state, typically because it has already started or another process has requested that it start/stop.
    /// </exception>
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

    /// <summary>
    /// Tries to stop the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// The result of the task is a boolean value indicating whether the attempt to stop the processor was successful.
    /// </returns>
    /// <exception cref="StopOperationInvalidException">
    /// The processor is not in a stopable state, typically because it is not started or another process has requested that it start/stop.
    /// </exception>
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

    /// <summary>
    /// Tries to start the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// The result of the task is a boolean value indicating whether the attempt to start the processor was successful.
    /// </returns>
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

    /// <summary>
    /// Tries to stop the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation.
    /// The result of the task is a boolean value indicating whether the attempt to stop the processor was successful.
    /// </returns>
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

    /// <summary>
    /// Determines if the process can be started.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the processor can be started, otherwise <c>false</c>.
    /// </returns>
    protected virtual bool CanStart()
    {
        return State == ProcessorState.Stopped;
    }

    /// <summary>
    /// Determines if the process can be stopped.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the processor can be stopped, otherwise <c>false</c>.
    /// </returns>
    protected virtual bool CanStop()
    {
        return State == ProcessorState.Started;
    }

    /// <summary>
    /// Asynchronously raises the <see cref="StateChanged"/> event when the processing state changes.
    /// </summary>
    /// <param name="state">The new processing state.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected virtual Task OnProcessingStateChangedAsync(ProcessorState state, CancellationToken? cancellationToken = default)
    {
        return StateChanged.PassiveInvokeAsync(
            this,
            new ProcessorStateChangedAsyncEventArgs(state),
            onFailure: failure => Diagnostics.EmitAsync(
                cancellationToken: cancellationToken,
                cause: failure,
                impact: Impact.None,
                message: ProcessorOnProcessingStateChangedAsyncFailure));
    }

    /// <summary>
    /// Faciliates implementation of the the neccessary operations to start the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected abstract Task PerformStartAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Faciliates implementation of the the neccessary operations to stop the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected abstract Task PerformStopAsync(CancellationToken cancellationToken);
}