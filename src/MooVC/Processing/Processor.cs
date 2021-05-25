namespace MooVC.Processing
{
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

        public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

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
                await
                    OnDiagnosticsEmittedAsync(
                        Level.Error,
                        cancellationToken: cancellationToken,
                        cause: ex,
                        message: ProcessorTryStartFailure)
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
                await
                    OnDiagnosticsEmittedAsync(
                        Level.Error,
                        cancellationToken: cancellationToken,
                        cause: ex,
                        message: ProcessorTryStopFailure)
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

        protected virtual Task OnDiagnosticsEmittedAsync(
            Level level,
            CancellationToken? cancellationToken = default,
            Exception? cause = default,
            string? message = default)
        {
            return DiagnosticsEmitted.PassiveInvokeAsync(
                this,
                new DiagnosticsEmittedAsyncEventArgs(
                    cancellationToken: cancellationToken,
                    cause: cause,
                    level: level,
                    message: message));
        }

        protected virtual Task OnProcessingStateChangedAsync(
            ProcessorState state,
            CancellationToken? cancellationToken = default)
        {
            return ProcessStateChanged.PassiveInvokeAsync(
                this,
                new ProcessorStateChangedAsyncEventArgs(state),
                onFailure: failure => OnDiagnosticsEmittedAsync(
                    Level.Warning,
                    cancellationToken: cancellationToken,
                    cause: failure,
                    message: ProcessorOnProcessingStateChangedAsyncFailure));
        }

        protected abstract Task PerformStartAsync(CancellationToken cancellationToken);

        protected abstract Task PerformStopAsync(CancellationToken cancellationToken);
    }
}