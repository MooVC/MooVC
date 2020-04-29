namespace MooVC.Processing
{
    using System;
    using static Resources;

    public sealed class StartOperationInvalidException
        : InvalidOperationException
    {
        public StartOperationInvalidException(ProcessorState state)
            : base(StartOperationInvalidExceptionMessage)
        {
            State = state;
        }

        public ProcessorState State { get; }
    }
}