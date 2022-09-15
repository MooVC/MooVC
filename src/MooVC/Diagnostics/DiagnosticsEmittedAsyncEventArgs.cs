namespace MooVC.Diagnostics;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Threading;
using MooVC.Serialization;
using static System.String;

[Serializable]
public sealed class DiagnosticsEmittedAsyncEventArgs
    : AsyncEventArgs,
      ISerializable
{
    private Exception? cause;
    private Impact impact = Impact.None;
    private Level level = Level.Information;
    private string message = string.Empty;

    public DiagnosticsEmittedAsyncEventArgs(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact impact = Impact.None,
        Level level = Level.Information,
        string? message = default)
        : base(cancellationToken: cancellationToken)
    {
        Cause = cause;
        Impact = impact;
        Level = level;
        Message = message;
    }

    private DiagnosticsEmittedAsyncEventArgs(SerializationInfo info, StreamingContext context)
        : base(default)
    {
        cause = info.TryGetValue<Exception?>(nameof(Cause));
        Impact = info.TryGetValue(nameof(Impact), defaultValue: Impact.None);
        level = info.TryGetValue(nameof(Level), defaultValue: Level.Information);
        message = info.TryGetString(nameof(Message));
    }

    public Exception? Cause
    {
        get => cause;
        private set
        {
            if (value is { } && IsNullOrWhiteSpace(Message))
            {
                Message = value.Message;
            }

            cause = value;
        }
    }

    public Impact Impact
    {
        get => impact;
        private set
        {
            if (Enum.IsDefined(typeof(Impact), value))
            {
                impact = value;
            }
            else
            {
                impact = Impact.None;
            }
        }
    }

    public Level Level
    {
        get => level;
        private set
        {
            if (Enum.IsDefined(typeof(Level), value))
            {
                level = value;
            }
            else
            {
                level = Level.Critical;
            }
        }
    }

    [AllowNull]
    public string Message
    {
        get => message;
        private set
        {
            if (IsNullOrWhiteSpace(value))
            {
                message = Cause?.Message ?? string.Empty;
            }
            else
            {
                message = value;
            }
        }
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddValue(nameof(Cause), Cause);
        _ = info.TryAddValue(nameof(Impact), Impact, defaultValue: Impact.None);
        _ = info.TryAddValue(nameof(Level), Level, defaultValue: Level.Information);
        _ = info.TryAddString(nameof(Message), Message);
    }
}