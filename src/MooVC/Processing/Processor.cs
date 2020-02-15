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
        private const int StartedFlag = 1;
        private const int StoppedFlag = 0;

        private Thread? continuationThread;
        private ProcessorState state;
        private volatile int flag = StoppedFlag;

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
            try
            {
                Start();

                return true;
            }
            catch (Exception ex)
            {
                OnFailureEncountered(Format(ProcessorStartFailure, GetType().Name), ex);
            }

            return false;
        }

        public bool TryStop()
        {
            try
            {
                Stop();

                return true;
            }
            catch (Exception ex)
            {
                OnFailureEncountered(Format(ProcessorStopFailure, GetType().Name), ex);
            }

            return false;
        }

        public void Start()
        {
            if (Interlocked.CompareExchange(ref flag, StartedFlag, StoppedFlag) == StartedFlag)
            {
                throw new StartOperationInvalidException(State);
            }

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

        public void Stop()
        {
            if (Interlocked.CompareExchange(ref flag, StoppedFlag, StartedFlag) == StoppedFlag)
            {
                throw new StopOperationInvalidException(State);
            }

            State = ProcessorState.Stopping;

            if (PerformStop() && continuationThread is { })
            {
                AbortContinuationThread();
            }

            State = ProcessorState.Stopped;
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
    }
}