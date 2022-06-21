namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static IEnumerable<T> GetInternalEnumerable<T>(this SerializationInfo info, string name)
    {
        return info.GetEnumerable<T>(FormatName(name));
    }
}