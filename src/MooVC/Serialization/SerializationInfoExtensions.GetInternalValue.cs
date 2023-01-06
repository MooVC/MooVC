namespace MooVC.Serialization;

using System;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static object? GetInternalValue(this SerializationInfo info, string name, Type type)
    {
        return info.GetValue(FormatName(name), type);
    }

    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static T GetInternalValue<T>(this SerializationInfo info, string name)
    {
        return info.GetValue<T>(FormatName(name));
    }
}