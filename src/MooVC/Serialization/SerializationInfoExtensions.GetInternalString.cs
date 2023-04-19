namespace MooVC.Serialization;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using static System.String;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static string GetInternalString(this SerializationInfo info, string name)
    {
        return info.GetInternalString(name, defaultValue: Empty);
    }

    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    [return: NotNullIfNotNull("defaultValue")]
    public static string? GetInternalString(this SerializationInfo info, string name, string? defaultValue = default)
    {
        return info.GetString(FormatName(name));
    }
}