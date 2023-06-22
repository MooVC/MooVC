namespace MooVC.Serialization;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static bool TryAddInternalEnumerable<T>(
        this SerializationInfo info,
        string name,
#if NET6_0_OR_GREATER
        [NotNullWhen(true)]
#endif
        IEnumerable<T>? value,
        Func<IEnumerable<T>, bool>? predicate = default)
    {
        return info.TryAddEnumerable(FormatName(name), value, predicate: predicate);
    }
}