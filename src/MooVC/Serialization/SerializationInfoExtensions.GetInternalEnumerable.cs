namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v8 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static IEnumerable<T> GetInternalEnumerable<T>(this SerializationInfo info, string name)
    {
        return info.GetEnumerable<T>(FormatName(name));
    }
}