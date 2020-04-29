namespace MooVC.Processing
{
    using System;
    using static Resources;

    public sealed class StopOperationInvalidException
        : InvalidOperationException
    {
        public StopOperationInvalidException(ProcessorState state)
            : base(StopOperationInvalidExceptionMessage)
        {
            State = state;
        }

        public ProcessorState State { get; }
    }
}