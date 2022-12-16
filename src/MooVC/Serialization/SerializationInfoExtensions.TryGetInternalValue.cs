namespace MooVC.Serialization;

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    [return: NotNullIfNotNull("defaultValue")]
    public static T? TryGetInternalValue<T>(this SerializationInfo info, string name, T? defaultValue = default)
    {
        return info.TryGetValue(FormatName(name), defaultValue: defaultValue);
    }
}