namespace MooVC.Processing
{
    using System;
    using System.Runtime.Serialization;
    using MooVC.Serialization;

    [Serializable]
    public sealed class ProcessorStateChangedEventArgs
        : EventArgs,
          ISerializable
    {
        public ProcessorStateChangedEventArgs(ProcessorState state)
        {
            State = state;
        }

        private ProcessorStateChangedEventArgs(SerializationInfo info, StreamingContext context)
        {
            State = info.GetValue<ProcessorState>(nameof(State));
        }

        public ProcessorState State { get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(State), State);
        }
    }
}