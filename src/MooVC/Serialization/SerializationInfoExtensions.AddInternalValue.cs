namespace MooVC.Serialization;

using System;
using System.Globalization;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, short value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, char value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, byte value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, bool value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, decimal value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, ulong value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, double value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, uint value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, float value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, sbyte value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, object value, Type type)
    {
        info.AddValue(FormatName(name), value, type);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, object value)
    {
        info.AddValue(FormatName(name), value, value.GetType());
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, long value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, int value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, ushort value)
    {
        info.AddValue(FormatName(name), value);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalValue(this SerializationInfo info, string name, DateTime value)
    {
        info.AddValue(FormatName(name), value);
    }

    private static string FormatName(string name)
    {
        return $"_{name.ToLower(CultureInfo.InvariantCulture)}";
    }
}