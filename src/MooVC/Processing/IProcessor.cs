namespace MooVC.Processing
{
    using System;

    public interface IProcessor
    {
        event ProcessorStateChangedEventHandler ProcessStateChanged;

        ProcessorState State { get; }

        void Start();

        void Stop();
    }
}