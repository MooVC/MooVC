namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;
using MooVC.Collections.Generic;

public static partial class SerializationInfoExtensions
{
    public static void AddEnumerable<T>(this SerializationInfo info, string name, IEnumerable<T> value)
    {
        info.AddValue(name, value.Snapshot());
    }
}