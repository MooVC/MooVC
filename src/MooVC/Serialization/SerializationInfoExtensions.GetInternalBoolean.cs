namespace MooVC.Serialization;

using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v9 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static bool GetInternalBoolean(this SerializationInfo info, string name)
    {
        return info.GetBoolean(FormatName(name));
    }
}