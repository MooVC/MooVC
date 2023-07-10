namespace MooVC.Collections.Concurrent;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides extensions relating to IProducerConsumerCollection{T}.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the collection.</typeparam>
public static partial class ProducerConsumerCollectionExtensions
{
    /// <summary>
    /// Extracts all elements from a producer consumer collection.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the collection.</typeparam>
    /// <param name="source">The collection from which the elements are to be extracted.</param>
    /// <param name="count">The total number of elements to extract (extracts all elements by default).</param>
    /// <returns>A readonly list containing the extracted elements.</returns>
    public static IReadOnlyList<T> Extract<T>(this IProducerConsumerCollection<T>? source, ulong? count = default)
    {
        if (source is null || source.Count == 0)
        {
            return Array.Empty<T>();
        }

        int total = source.Count;

        if (count.HasValue)
        {
            total = Math.Min(total, (int)count.Value);
        }

        var taken = new T[total];
        int index = 0;

        while (index < total && source.TryTake(out T? current))
        {
            taken[index++] = current;
        }

        return taken;
    }
}