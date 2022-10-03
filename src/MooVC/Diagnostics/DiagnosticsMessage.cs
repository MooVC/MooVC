namespace MooVC.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MooVC.Collections.Generic;
using MooVC.Linq;
using MooVC.Serialization;
using static System.String;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

[Serializable]
public sealed class DiagnosticsMessage
    : ISerializable,
      IEquatable<string>
{
    private static readonly Lazy<DiagnosticsMessage> empty = new(() => new DiagnosticsMessage());
    private readonly Lazy<string> @string;

    public DiagnosticsMessage(string description, params object[] arguments)
        : this()
    {
        Description = IsNotNullOrWhiteSpace(description, message: DiagnosticsMessageDescriptionRequired);
        Arguments = arguments.Snapshot();
    }

    private DiagnosticsMessage(SerializationInfo info, StreamingContext context)
        : this()
    {
        Arguments = info.TryGetEnumerable<object>(nameof(Arguments));
        Description = info.TryGetString(nameof(Description));

        @string = new(GetString);
    }

    private DiagnosticsMessage()
    {
        @string = new(GetString);
    }

    public static DiagnosticsMessage Empty => empty.Value;

    public IEnumerable<object> Arguments { get; } = Enumerable.Empty<object>();

    public string Description { get; } = string.Empty;

    public bool IsEmpty => this == Empty;

    public static implicit operator object[](DiagnosticsMessage? message)
    {
        if (message is null)
        {
            return Array.Empty<object>();
        }

        return message.Arguments.ToArray();
    }

    public static implicit operator DiagnosticsMessage(string? description)
    {
        if (IsNullOrWhiteSpace(description))
        {
            return Empty;
        }

        return new DiagnosticsMessage(description);
    }

    public static implicit operator DiagnosticsMessage((string Description, object Argument1) message)
    {
        return (message.Description, new[] { message.Argument1 });
    }

    public static implicit operator DiagnosticsMessage((string Description, object Argument1, object Argument2) message)
    {
        return (message.Description, new[] { message.Argument1, message.Argument2 });
    }

    public static implicit operator DiagnosticsMessage((string Description, object Argument1, object Argument2, object Argument3) message)
    {
        return (message.Description, new[] { message.Argument1, message.Argument2, message.Argument3 });
    }

    public static implicit operator DiagnosticsMessage((string Description, object[] Arguments) message)
    {
        if (IsNullOrWhiteSpace(message.Description) && message.Arguments.IsEmpty())
        {
            return Empty;
        }

        return new DiagnosticsMessage(message.Description, message.Arguments);
    }

    public static implicit operator string(DiagnosticsMessage? message)
    {
        if (message is null)
        {
            return Empty;
        }

        return message.ToString();
    }

    public static bool operator ==(DiagnosticsMessage message, string? value)
    {
        return message.Equals(value);
    }

    public static bool operator !=(DiagnosticsMessage message, string? value)
    {
        return !message.Equals(value);
    }

    public override bool Equals(object? other)
    {
        if (other is string @string)
        {
            return Equals(@string);
        }

        if (other is DiagnosticsMessage message)
        {
            return GetHashCode() == message.GetHashCode();
        }

        return false;
    }

    public bool Equals(string? other)
    {
        if (other is null)
        {
            return false;
        }

        return ToString() == other;
    }

    public override int GetHashCode()
    {
        return ToString()
            .GetHashCode();
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddEnumerable(nameof(Arguments), Arguments);
        _ = info.TryAddString(nameof(Description), Description);
    }

    public override string ToString()
    {
        return @string.Value;
    }

    private string GetString()
    {
        if (Arguments.Any())
        {
            return Format(Description, Arguments.ToArray());
        }

        return Description;
    }
}