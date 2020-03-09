namespace MooVC.Processing
{
    using System;

    public sealed class StartOperationInvalidException
        : InvalidOperationException
    {
        public StartOperationInvalidException(ProcessorState state)
            : base(string.Format(Resources.StartOperationInvalidExceptionMessage, state))
        {
            State = state;
        }

        public ProcessorState State { get; }
    }
}