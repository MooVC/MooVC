namespace MooVC.Processing
{
    public interface IProcessor
    {
        event ProcessorStateChangedEventHandler ProcessStateChanged;

        ProcessorState State { get; }

        bool TryStart();

        bool TryStop();

        void Start();

        void Stop();
    }
}