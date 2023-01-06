﻿namespace MooVC.Serialization;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using static System.String;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static string TryGetInternalString(this SerializationInfo info, string name)
    {
        return info.TryGetInternalString(name, Empty);
    }

    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    [return: NotNullIfNotNull("defaultValue")]
    public static string? TryGetInternalString(this SerializationInfo info, string name, string? defaultValue)
    {
        return info.TryGetString(FormatName(name), defaultValue: defaultValue);
    }
}