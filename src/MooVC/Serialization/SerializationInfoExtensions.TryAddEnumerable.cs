namespace MooVC.Serialization;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using MooVC.Linq;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v9 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static bool TryAddEnumerable<T>(
        this SerializationInfo info,
        string name,
        [NotNullWhen(true)] IEnumerable<T>? value,
        Func<IEnumerable<T>, bool>? predicate = default)
    {
        if (value is { })
        {
            predicate ??= input => input.SafeAny();

            if (predicate(value))
            {
                info.AddEnumerable(name, value);

                return true;
            }
        }

        return false;
    }
}