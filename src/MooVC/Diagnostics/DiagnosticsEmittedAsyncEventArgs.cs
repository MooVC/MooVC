namespace MooVC.Diagnostics;

using System;
using System.Runtime.Serialization;
using System.Threading;
using MooVC.Serialization;
using static System.String;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

[Serializable]
public sealed class DiagnosticsEmittedAsyncEventArgs
    : AsyncEventArgs,
      ISerializable
{
    public DiagnosticsEmittedAsyncEventArgs(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact impact = Impact.None,
        Level level = Level.Information,
        DiagnosticsMessage? message = default)
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

    private DiagnosticsEmittedAsyncEventArgs(SerializationInfo info, StreamingContext context)
        : base(default)
    {
        Cause = info.TryGetValue<Exception?>(nameof(Cause));
        Impact = info.TryGetValue(nameof(Impact), defaultValue: Impact.None);
        Level = info.TryGetValue(nameof(Level), defaultValue: Level.Information);
        Message = info.TryGetValue(nameof(Message), defaultValue: DiagnosticsMessage.Empty);
    }

    public Exception? Cause { get; }

    public Impact Impact { get; } = Impact.None;

    public Level Level { get; } = Level.Trace;

    public DiagnosticsMessage Message { get; }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddValue(nameof(Cause), Cause);
        _ = info.TryAddValue(nameof(Impact), Impact, defaultValue: Impact.None);
        _ = info.TryAddValue(nameof(Level), Level, defaultValue: Level.Information);
        _ = info.TryAddValue(nameof(Message), Message, defaultValue: DiagnosticsMessage.Empty);
    }
}