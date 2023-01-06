namespace MooVC.Collections.Concurrent;

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

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
    /// <returns>An enumerable containing the extracted elements.</returns>
    public static IEnumerable<T> Extract<T>(this IProducerConsumerCollection<T>? source, ulong? count = default)
    {
        if (source is null)
        {
            return Enumerable.Empty<T>();
        }

        IList<T> taken = count.HasValue && count.Value <= int.MaxValue
            ? new List<T>((int)count.Value)
            : new List<T>();

        ulong index = 0;

        count ??= ulong.MaxValue;

        while (index++ < count && source.TryTake(out T? current))
        {
            taken.Add(current);
        }

        return taken.ToArray();
    }
}