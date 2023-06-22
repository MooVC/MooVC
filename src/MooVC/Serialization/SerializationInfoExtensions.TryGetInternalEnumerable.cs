﻿namespace MooVC.Serialization;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static IEnumerable<T> TryGetInternalEnumerable<T>(this SerializationInfo info, string name)
    {
        return info.TryGetInternalEnumerable(name, Array.Empty<T>())!;
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
#if NET6_0_OR_GREATER
    [return: NotNullIfNotNull(nameof(defaultValue))]
#endif
    public static IEnumerable<T>? TryGetInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T>? defaultValue)
    {
        return info.TryGetEnumerable(FormatName(name), defaultValue);
    }
}