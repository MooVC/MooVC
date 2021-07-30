namespace MooVC.Processing
{
    using System;
    using System.Runtime.Serialization;
    using MooVC.Serialization;
    using static MooVC.Processing.Resources;

    public sealed class StopOperationInvalidException
        : InvalidOperationException
    {
        public StopOperationInvalidException(ProcessorState state)
            : base(StopOperationInvalidExceptionMessage)
        {
            State = state;
        }

        private StopOperationInvalidException(SerializationInfo info, StreamingContext context)
        {
            State = info.GetValue<ProcessorState>(nameof(State));
        }

        public ProcessorState State { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(State), State);
        }
    }
}