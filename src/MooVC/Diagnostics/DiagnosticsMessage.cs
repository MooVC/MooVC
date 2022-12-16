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

/// <summary>
/// Represents a friendly message relating to a diagnostics event.
/// </summary>
[Serializable]
public sealed class DiagnosticsMessage
    : ISerializable,
      IEquatable<string>
{
    private static readonly Lazy<DiagnosticsMessage> empty = new(() => new DiagnosticsMessage());
    private readonly Lazy<string> @string;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiagnosticsMessage"/> class.
    /// </summary>
    /// <param name="description">The friendly description of the event.</param>
    /// <param name="arguments">The arguments relating to the friendly description of the event.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="description"/> is null.</exception>
    /// <exception cref="ArgumentException">The <paramref name="description"/> is whitespace.</exception>
    public DiagnosticsMessage(string description, params object[] arguments)
        : this()
    {
        Description = IsNotNullOrWhiteSpace(description, message: DiagnosticsMessageDescriptionRequired);
        Arguments = arguments.Snapshot();
    }

    /// <summary>
    /// Supports deserialization of an instance of the <see cref="DiagnosticsMessage"/> class
    /// via the specified <paramref name="info"/> and <paramref name="context"/>.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that holds the serialized object data relating to the instance.</param>
    /// <param name="context">The <see cref="StreamingContext"/> object that contains contextual information about the stream.</param>
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    private DiagnosticsMessage(SerializationInfo info, StreamingContext context)
        : this()
    {
        Arguments = info.TryGetEnumerable<object>(nameof(Arguments));
        Description = info.TryGetString(nameof(Description));

        @string = new(GetString);
    }

    /// <summary>
    /// Initializes a default instance of the <see cref="DiagnosticsMessage"/> class.
    /// </summary>
    private DiagnosticsMessage()
    {
        @string = new(GetString);
    }

    /// <summary>
    /// Gets the default instance of the <see cref="DiagnosticsMessage"/> class.
    /// </summary>
    /// <value>
    /// The default instance of the <see cref="DiagnosticsMessage"/> class.
    /// </value>
    public static DiagnosticsMessage Empty => empty.Value;

    /// <summary>
    /// Gets the arguments relating to the friendly description of the event.
    /// </summary>
    /// <value>
    /// The arguments relating to the friendly description of the event.
    /// </value>
    public IEnumerable<object> Arguments { get; } = Enumerable.Empty<object>();

    /// <summary>
    /// Gets the friendly description of the event.
    /// </summary>
    /// <value>
    /// The friendly description of the event.
    /// </value>
    public string Description { get; } = string.Empty;

    /// <summary>
    /// Gets the flag which indicates whether or not the current instance is the default instance.
    /// </summary>
    /// <value>
    /// The flag which indicates whether or not the current instance is the default instance.
    /// </value>
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

    /// <summary>
    /// Gets the hash code associated with the instance of <see cref="DiagnosticsMessage"/>.
    /// </summary>
    /// <returns>The hash code associated with the instance of <see cref="DiagnosticsMessage"/>.</returns>
    public override int GetHashCode()
    {
        return ToString()
            .GetHashCode();
    }

    /// <summary>
    /// Populates the specified <see cref="SerializationInfo"/> object with the data needed to serialize the current instance
    /// of the <see cref="DiagnosticsMessage"/> class.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"/> object that will be populated with data.</param>
    /// <param name="context">The destination (see <see cref="StreamingContext"/>) for the serialization operation.</param>
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        _ = info.TryAddEnumerable(nameof(Arguments), Arguments);
        _ = info.TryAddString(nameof(Description), Description);
    }

    /// <summary>
    /// Gets the friendly description of the event formatted with the arguments provided, if any.
    /// </summary>
    /// <returns>The friendly description of the event formatted with the arguments provided, if any.</returns>
    public override string ToString()
    {
        return @string.Value;
    }

    /// <summary>
    /// Formats the friendly description of the event with the arguments provided, if any.
    /// </summary>
    /// <returns>The friendly description of the event formatted with the arguments provided, if any.</returns>
    private string GetString()
    {
        if (Arguments.Any())
        {
            return Format(Description, Arguments.ToArray());
        }

        return Description;
    }
}