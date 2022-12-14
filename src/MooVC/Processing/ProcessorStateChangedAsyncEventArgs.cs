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

    /// <summary>
    /// Supports deserialization of an instance of the <see cref="ProcessorStateChangedAsyncEventArgs"/> class
    /// via the specified <paramref name="info"/> and <paramref name="context"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that holds the serialized object data relating to the instance.</param>
    /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information about the stream.</param>
    private ProcessorStateChangedAsyncEventArgs(SerializationInfo info, StreamingContext context)
    {
        State = info.GetValue<ProcessorState>(nameof(State));
    }

    public ProcessorState State { get; }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="ProcessorStateChangedAsyncEventArgs"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(State), State);
    }
}