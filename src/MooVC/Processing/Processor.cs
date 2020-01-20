﻿namespace MooVC.Processing
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
        private Thread? continuationThread;
        private ProcessorState state;

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

        public void Start()
        {
            if (State != ProcessorState.Stopped)
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
            if (State == ProcessorState.Stopped)
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

        protected void EmitFailure(string message, Exception failure)
        {
            FailureEmitted?.Invoke(this, new PassiveExceptionEventArgs(message, failure));
        }

        protected void EmitWarning(string message, Exception warning)
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
                EmitWarning(
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
                    EmitFailure(
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