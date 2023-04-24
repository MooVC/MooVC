namespace MooVC.Processing;

using System;
using System.Runtime.Serialization;
using MooVC.Serialization;
using static MooVC.Processing.Resources;

/// <summary>
/// Encapsulates information relating to a failed attempt to stop an instance of <see cref="IProcessor"/>.
/// </summary>
[Serializable]
public sealed class StopOperationInvalidException
    : InvalidOperationException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StopOperationInvalidException" /> class.
    /// </summary>
    /// <param name="state">The state of the processor was in at the time the request to stop was made.</param>
    public StopOperationInvalidException(ProcessorState state)
        : base(StopOperationInvalidExceptionMessage)
    {
        State = state;
    }

    /// <summary>
    /// Supports deserialization of an instance of the <see cref="StopOperationInvalidException"/> class
    /// via the specified <paramref name="info"/> and <paramref name="context"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that holds the serialized object data relating to the instance.</param>
    /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information about the stream.</param>
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    private StopOperationInvalidException(SerializationInfo info, StreamingContext context)
    {
        State = info.GetValue<ProcessorState>(nameof(State));
    }

    /// <summary>
    /// Gets the state of the processor was in at the time the request to stop was made.
    /// </summary>
    /// <value>
    /// The state of the processor was in at the time the request to stop was made.
    /// </value>
    public ProcessorState State { get; }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="StopOperationInvalidException"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);

        info.AddValue(nameof(State), State);
    }
}