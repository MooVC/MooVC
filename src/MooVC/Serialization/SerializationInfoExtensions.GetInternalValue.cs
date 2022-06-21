namespace MooVC.Serialization;

using System;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static object? GetInternalValue(this SerializationInfo info, string name, Type type)
    {
        return info.GetValue(FormatName(name), type);
    }

    public static T GetInternalValue<T>(this SerializationInfo info, string name)
    {
        return info.GetValue<T>(FormatName(name));
    }
}