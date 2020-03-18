namespace MooVC.Processing
{
    using System;
    using System.Threading;
    using MooVC.Logging;
    using static System.String;
    using static Resources;

    public abstract class Processor
        : IEmitFailures,
          IEmitWarnings,
          IProcessor
    {
        private const int StartRequestedFlag = 1;
        private const int StopRequestedFlag = 0;

        private Thread? continuationThread;
        private ProcessorState state;
        private volatile int flag = StopRequestedFlag;

        protected Processor()
        {
            state = ProcessorState.Stopped;
        }

        public event PassiveExceptionEventHandler? FailureEmitted;

        public event ProcessorStateChangedEventHandler? ProcessStateChanged;

        public event PassiveExceptionEventHandler? WarningEmitted;

        public ProcessorState State
        {
            get => state;
            private set
            {
                if (state != value)
                {
                    state = value;

                    ProcessStateChanged?.Invoke(this, new ProcessorStateChangedEventArgs(value));
                }
            }
        }

        public bool TryStart()
        {
            if (RequestStart())
            {
                try
                {
                    ExecuteStart();

                    return true;
                }
                catch (Exception ex)
                {
                    OnFailureEncountered(Format(ProcessorStartFailure, GetType().Name), ex);
                }
            }

            return false;
        }

        public bool TryStop()
        {
            if (RequestStop())
            {
                try
                {
                    ExecuteStop();

                    return true;
                }
                catch (Exception ex)
                {
                    OnFailureEncountered(Format(ProcessorStopFailure, GetType().Name), ex);
                }
            }

            return false;
        }

        public void Start()
        {
            if (!RequestStart())
            {
                throw new StartOperationInvalidException(State);
            }

            ExecuteStart();
        }

        public void Stop()
        {
            if (!RequestStop())
            {
                throw new StopOperationInvalidException(State);
            }

            ExecuteStop();
        }

        protected virtual void PerformContinue()
        {
        }

        protected virtual bool PerformStart()
        {
            return true;
        }

        protected virtual bool PerformStop()
        {
            return true;
        }

        protected void OnFailureEncountered(string message, Exception failure)
        {
            FailureEmitted?.Invoke(this, new PassiveExceptionEventArgs(message, failure));
        }

        protected void OnWarningEncountered(string message, Exception warning)
        {
            WarningEmitted?.Invoke(this, new PassiveExceptionEventArgs(message, warning));
        }

        private void AbortContinuationThread()
        {
            try
            {
                continuationThread!.Abort();
                continuationThread.Join();
            }
            catch (Exception ex)
            {
                OnWarningEncountered(
                    Format(ProcessorContinuationAbortFailure, GetType().Name),
                    ex);
            }
        }

        private void Continue()
        {
            continuationThread = new Thread(() =>
            {
                try
                {
                    PerformContinue();
                }
                catch (ThreadAbortException)
                {
                    Thread.ResetAbort();
                }
                catch (Exception ex)
                {
                    OnFailureEncountered(
                        Format(ProcessorContinuationInteruppted, GetType().Name),
                        ex);
                }

                continuationThread = null;

                if (State == ProcessorState.Started)
                {
                    Stop();
                }
            });

            continuationThread.Start();
        }

        private void ExecuteStart()
        {
            State = ProcessorState.Starting;

            try
            {
                bool shouldContinue = PerformStart();

                State = ProcessorState.Started;

                if (shouldContinue)
                {
                    Continue();
                }
            }
            catch
            {
                Stop();

                throw;
            }
        }

        private void ExecuteStop()
        {
            State = ProcessorState.Stopping;

            if (PerformStop() && continuationThread is { })
            {
                AbortContinuationThread();
            }

            State = ProcessorState.Stopped;
        }

        private bool RequestStart()
        {
            return Interlocked.CompareExchange(ref flag, StartRequestedFlag, StopRequestedFlag) == StopRequestedFlag;
        }

        private bool RequestStop()
        {
            return Interlocked.CompareExchange(ref flag, StopRequestedFlag, StartRequestedFlag) == StartRequestedFlag;
        }
    }
}