namespace MooVC.Serialization;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static IEnumerable<T> TryGetEnumerable<T>(this SerializationInfo info, string name)
    {
        return info.TryGetValue(name, Array.Empty<T>());
    }

    [return: NotNullIfNotNull("defaultValue")]
    public static IEnumerable<T>? TryGetEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T>? defaultValue)
    {
        T[]? value = info.TryGetValue<T[]>(name);

        if (value is { })
        {
            return value;
        }

        return defaultValue;
    }
}