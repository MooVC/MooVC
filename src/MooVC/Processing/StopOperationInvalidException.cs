namespace MooVC.Processing
{
    using System;

    public sealed class StopOperationInvalidException 
        : InvalidOperationException
    {
        public StopOperationInvalidException(ProcessorState state)
            : base(string.Format(Resources.StopOperationInvalidExceptionMessage, state))
        {
            State = state;
        }

        public ProcessorState State { get; }
    }
}