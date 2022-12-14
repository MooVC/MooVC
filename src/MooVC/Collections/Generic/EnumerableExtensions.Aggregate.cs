namespace MooVC.Collections.Generic;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Matches elements of the <paramref name="items"/> enumeration against the keys of the <paramref name="source"/> dictionary and returns
    /// their associated <typeparamref name="TResult"/> values.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration and the dictionary keys.</typeparam>
    /// <typeparam name="TResult">Specifies the type of values in the dictionary.</typeparam>
    /// <param name="items">The enumeration from which the contents are to be matched.</param>
    /// <param name="source">The dictionary from which the results are to be extracted.</param>
    /// <returns>An enumerable containing the <typeparamref name="TResult"/> values that match the contents of <paramref name="items"/>.</returns>
    public static IEnumerable<TResult> Aggregate<T, TResult>(this IEnumerable<T>? items, IDictionary<T, TResult>? source)
    {
        if (items is { } && source is { })
        {
            var results = new List<TResult>();

            foreach (T item in items)
            {
                if (source.TryGetValue(item, out TResult? result))
                {
                    results.Add(result);
                }
            }

            return results.ToArray();
        }

        return Enumerable.Empty<TResult>();
    }
}