namespace MooVC.Processing
{
    using System;

    public interface IProcessor
    {
        event EventHandler<ProcessorStateChangedEventArgs> ProcessStateChanged;

        ProcessorState State { get; }

        void Start();

        void Stop();
    }
}