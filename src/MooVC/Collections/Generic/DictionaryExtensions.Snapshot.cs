namespace MooVC.Collections.Generic;

using System.Collections.Generic;

public static partial class DictionaryExtensions
{
    public static IDictionary<TKey, TValue> Snapshot<TKey, TValue>(this IDictionary<TKey, TValue>? source)
        where TKey : notnull
    {
        var snapshot = new Dictionary<TKey, TValue>();

        source.ForEach(entry => snapshot.Add(entry.Key, entry.Value));

        return snapshot;
    }
}