namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
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