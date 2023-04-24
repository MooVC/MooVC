namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;
using MooVC.Collections.Generic;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
    {
        info.AddValue(name, value.Snapshot());
    }
}