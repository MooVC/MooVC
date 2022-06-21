namespace MooVC.Processing;

using System;
using System.Runtime.Serialization;
using System.Threading;
using MooVC.Serialization;

[Serializable]
public sealed class ProcessorStateChangedAsyncEventArgs
    : AsyncEventArgs,
      ISerializable
{
    public ProcessorStateChangedAsyncEventArgs(ProcessorState state, CancellationToken? cancellationToken = default)
        : base(cancellationToken: cancellationToken)
    {
        State = state;
    }

    private ProcessorStateChangedAsyncEventArgs(SerializationInfo info, StreamingContext context)
    {
        State = info.GetValue<ProcessorState>(nameof(State));
    }

    public ProcessorState State { get; }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(State), State);
    }
}