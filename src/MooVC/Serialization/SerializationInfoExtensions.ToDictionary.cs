namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;

public static partial class SerializationInfoExtensions
{
    public static IDictionary<string, object?> ToDictionary(this SerializationInfo info)
    {
        SerializationInfoEnumerator enumerator = info.GetEnumerator();

        return enumerator.ToDictionary();
    }
}