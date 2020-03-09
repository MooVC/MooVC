namespace MooVC.Processing
{
    using System;

    public sealed class ProcessorStateChangedEventArgs
        : EventArgs
    {
        internal ProcessorStateChangedEventArgs(ProcessorState state)
        {
            State = state;
        }

        public ProcessorState State { get; }
    }
}