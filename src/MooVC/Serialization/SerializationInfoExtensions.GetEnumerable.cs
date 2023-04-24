namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static IEnumerable<T> GetEnumerable<T>(this SerializationInfo info, string name)
    {
        object? value = info.GetValue<T[]>(name);

        if (value is T[] result)
        {
            return result;
        }

        return Enumerable.Empty<T>();
    }
}