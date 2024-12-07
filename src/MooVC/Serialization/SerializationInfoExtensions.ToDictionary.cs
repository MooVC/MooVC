namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal in v9 as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static IDictionary<string, object?> ToDictionary(this SerializationInfo info)
    {
        SerializationInfoEnumerator enumerator = info.GetEnumerator();

        return enumerator.ToDictionary();
    }
}