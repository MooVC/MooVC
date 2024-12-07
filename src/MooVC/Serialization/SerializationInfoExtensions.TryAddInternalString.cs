namespace MooVC.Serialization;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v9 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
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