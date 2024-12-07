namespace MooVC.Processing;

using System;
using System.Runtime.Serialization;
using System.Threading;
using MooVC.Serialization;

/// <summary>
/// Represents the event data for the <see cref="IProcessor.StateChanged" /> event.
/// </summary>
[Serializable]
public sealed class ProcessorStateChangedAsyncEventArgs
    : AsyncEventArgs,
      ISerializable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessorStateChangedAsyncEventArgs" /> class.
    /// </summary>
    /// <param name="state">The state of the processor at the time the event was raised.</param>
    /// <param name="cancellationToken">
    /// An optional <see cref="CancellationToken" /> that can be used to cancel the operation that raised the event.
    /// </param>
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
    [Obsolete(@"Slated for removal in v9 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    private ProcessorStateChangedAsyncEventArgs(SerializationInfo info, StreamingContext context)
    {
        State = info.GetValue<ProcessorState>(nameof(State));
    }

    /// <summary>
    /// Gets the state of the processor at the time the event was raised.
    /// </summary>
    /// <value>
    /// The state of the processor at the time the event was raised.
    /// </value>
    public ProcessorState State { get; }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="ProcessorStateChangedAsyncEventArgs"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    [Obsolete(@"Slated for removal in v9 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue(nameof(State), State);
    }
}