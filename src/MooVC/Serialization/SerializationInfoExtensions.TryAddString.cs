namespace MooVC.Serialization;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using static System.String;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static bool TryAddString(
        this SerializationInfo info,
        string name,
#if NET6_0_OR_GREATER
        [NotNullWhen(true)]
#endif
        string? value,
        string? defaultValue = default,
        Func<string?, bool>? predicate = default)
    {
        predicate ??= input => !(IsNullOrEmpty(input) || input!.Equals(defaultValue, StringComparison.Ordinal));

        return info.TryAddValue(name, value, predicate: predicate);
    }
}