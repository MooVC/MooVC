namespace MooVC.Serialization;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static bool TryAddInternalString(
        this SerializationInfo info,
        string name,
        [NotNullWhen(true)] string? value,
        string? defaultValue = default,
        Func<string?, bool>? predicate = default)
    {
        return info.TryAddString(
            FormatName(name),
            value,
            defaultValue: defaultValue,
            predicate: predicate);
    }
}