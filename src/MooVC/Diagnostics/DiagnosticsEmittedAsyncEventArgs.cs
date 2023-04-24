namespace MooVC.Diagnostics;

using System;
using System.Runtime.Serialization;
using System.Threading;
using MooVC.Serialization;
using static System.String;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

/// <summary>
/// Represents the event data for the <see cref="IEmitDiagnostics.DiagnosticsEmitted" /> event.
/// </summary>
[Serializable]
public sealed class DiagnosticsEmittedAsyncEventArgs
    : AsyncEventArgs,
      ISerializable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DiagnosticsEmittedAsyncEventArgs" /> class.
    /// </summary>
    /// <param name="cause">An optional <see cref="Exception" /> that caused the emission of the event.</param>
    /// <param name="impact">An optional perceived <see cref="Impact" /> of the event from the perspective of the source.</param>
    /// <param name="level">An optional perceived <see cref="Level" /> of the event from the perspective of the source.</param>
    /// <param name="message">An optional <see cref="DiagnosticsMessage" /> providing a friendly description of the event.</param>
    /// <param name="cancellationToken">
    /// An optional <see cref="CancellationToken" /> that can be used to cancel the operation that raised the event.
    /// </param>
    public DiagnosticsEmittedAsyncEventArgs(
        Exception? cause = default,
        Impact impact = Impact.None,
        Level level = Level.Information,
        DiagnosticsMessage? message = default,
        CancellationToken cancellationToken = default)
        : base(cancellationToken: cancellationToken)
    {
        if (message is null || message.IsEmpty)
        {
            message = cause?.Message;
        }

        Impact = IsDefined(impact, @default: Impact);
        Level = IsDefined(level, @default: Level);
        Message = Satisfies(message, _ => !IsNullOrWhiteSpace(message), message: DiagnosticsEmittedAsyncEventArgsMessageRequired);
        Cause = cause;
    }

    /// <summary>
    /// Supports deserialization of an instance of the <see cref="DiagnosticsEmittedAsyncEventArgs"/> class
    /// via the specified <paramref name="info"/> and <paramref name="context"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that holds the serialized object data relating to the instance.</param>
    /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information about the stream.</param>
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    private DiagnosticsEmittedAsyncEventArgs(SerializationInfo info, StreamingContext context)
        : base(default)
    {
        Cause = info.TryGetValue<Exception?>(nameof(Cause));
        Impact = info.TryGetValue(nameof(Impact), defaultValue: Impact.None);
        Level = info.TryGetValue(nameof(Level), defaultValue: Level.Information);
        Message = info.TryGetValue(nameof(Message), defaultValue: DiagnosticsMessage.Empty);
    }

    /// <summary>
    /// Gets the <see cref="Exception" /> that caused the emission of the event, if any.
    /// </summary>
    /// <value>
    /// The <see cref="Exception" /> that caused the emission of the event, if any.
    /// </value>
    public Exception? Cause { get; }

    /// <summary>
    /// Gets the perceived <see cref="Impact" /> of the event from the perspective of the source.
    /// </summary>
    /// <value>
    /// The perceived <see cref="Impact" /> of the event from the perspective of the source.
    /// </value>
    public Impact Impact { get; } = Impact.None;

    /// <summary>
    /// Gets the perceived <see cref="Level" /> of the event from the perspective of the source.
    /// </summary>
    /// <value>
    /// The perceived <see cref="Level" /> of the event from the perspective of the source.
    /// </value>
    public Level Level { get; } = Level.Trace;

    /// <summary>
    /// Gets the <see cref="DiagnosticsMessage" /> providing a friendly description of the event.
    /// </summary>
    /// <value>
    /// The <see cref="DiagnosticsMessage" /> providing a friendly description of the event.
    /// </value>
    public DiagnosticsMessage Message { get; }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="DiagnosticsEmittedAsyncEventArgs"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddValue(nameof(Cause), Cause);
        _ = info.TryAddValue(nameof(Impact), Impact, defaultValue: Impact.None);
        _ = info.TryAddValue(nameof(Level), Level, defaultValue: Level.Information);
        _ = info.TryAddValue(nameof(Message), Message, defaultValue: DiagnosticsMessage.Empty);
    }
}