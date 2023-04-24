namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static void AddInternalEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
    {
        info.AddEnumerable(FormatName(name), value);
    }
}