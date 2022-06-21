﻿namespace MooVC.Serialization;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static IEnumerable<T> TryGetInternalEnumerable<T>(this SerializationInfo info, string name)
    {
        return info.TryGetInternalEnumerable(name, Array.Empty<T>());
    }

    [return: NotNullIfNotNull("defaultValue")]
    public static IEnumerable<T>? TryGetInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T>? defaultValue)
    {
        return info.TryGetEnumerable(FormatName(name), defaultValue);
    }
}