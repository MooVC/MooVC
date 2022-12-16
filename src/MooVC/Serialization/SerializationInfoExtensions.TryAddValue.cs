namespace MooVC.Serialization;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static bool TryAddValue<T>(
        this SerializationInfo info,
        string name,
        [NotNullWhen(true)] T? value,
        T? defaultValue = default,
        Func<T, bool>? predicate = default)
    {
        if (value is { })
        {
            predicate ??= input => input is { } && !input.Equals(defaultValue);

            if (predicate(value))
            {
                info.AddValue(name, value, value.GetType());

                return true;
            }
        }

        return false;
    }
}