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

        public event DiagnosticsEmittedEventHandler? DiagnosticsEmitted;

        public event ProcessorStateChangedEventHandler? ProcessStateChanged;

        public ProcessorState State
        {
            get => state;
            private set
            {
                if (state != value)
                {
                    state = value;

                    OnProcessingStateChanged(value);
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
                OnDiagnosticsEmitted(
                    Level.Error,
                    cause: ex,
                    message: ProcessorTryStartFailure);
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
                OnDiagnosticsEmitted(
                    Level.Error,
                    cause: ex,
                    message: ProcessorTryStopFailure);
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

        protected virtual void OnDiagnosticsEmitted(
            Level level,
            Exception? cause = default,
            string? message = default)
        {
            DiagnosticsEmitted?.PassiveInvoke(
                this,
                new DiagnosticsEmittedEventArgs(
                    cause: cause,
                    level: level,
                    message: message));
        }

        protected virtual void OnProcessingStateChanged(ProcessorState state)
        {
            ProcessStateChanged?.PassiveInvoke(
                this,
                new ProcessorStateChangedEventArgs(state),
                onFailure: failure => OnDiagnosticsEmitted(
                    Level.Warning,
                    cause: failure,
                    message: ProcessorOnProcessingStateChangedFailure));
        }

        protected abstract Task PerformStartAsync(CancellationToken cancellationToken);

        protected abstract Task PerformStopAsync(CancellationToken cancellationToken);
    }
}