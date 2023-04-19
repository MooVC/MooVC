namespace MooVC.Serialization;

using System.Collections.Generic;
using System.Runtime.Serialization;

public static partial class SerializationInfoEnumeratorExtensions
{
    [Obsolete(@"Slated for removal as part of Microsoft's BinaryFormatter Obsoletion Strategy.
                       (see: https://github.com/dotnet/designs/blob/main/accepted/2020/better-obsoletion/binaryformatter-obsoletion.md)")]
    public static IDictionary<string, object?> ToDictionary(this SerializationInfoEnumerator enumerator)
    {
        var contents = new Dictionary<string, object?>();

        while (enumerator.MoveNext())
        {
            contents[enumerator.Current.Name] = enumerator.Current.Value;
        }

        return contents;
    }
}