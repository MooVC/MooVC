namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions relating to IEnumerable{T}.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns a snapshot of an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
    /// <param name="enumerable">The sequence to take a snapshot of.</param>
    /// <param name="predicate">An optional function to test each element for a condition. If provided, only elements that satisfy the condition
    /// will be included in the snapshot.</param>
    /// <returns>An array that contains the elements of the snapshot.</returns>
    public static T[] Snapshot<T>(this IEnumerable<T>? enumerable, Func<T, bool>? predicate = default)
    {
        if (enumerable is { })
        {
            return enumerable
                .WhereIf(predicate is { }, predicate!)
                .ToArray();
        }

        return Array.Empty<T>();
    }

    /// <summary>
    /// Returns a snapshot of an enumerable sequence, ordered by the given key.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
    /// <typeparam name="TKey">The type of the order key.</typeparam>
    /// <param name="enumerable">The sequence to take a snapshot of.</param>
    /// <param name="order">The function to use to extract the key used to order the snapshot.</param>
    /// <param name="predicate">An optional function to test each element for a condition. If provided, only elements that satisfy the condition
    /// will be included in the snapshot.</param>
    /// <returns>An array that contains the elements of the snapshot, ordered by the given key.</returns>
    public static T[] Snapshot<T, TKey>(this IEnumerable<T>? enumerable, Func<T, TKey> order, Func<T, bool>? predicate = default)
    {
        _ = IsNotNull(order, message: EnumerableExtensionsSnapshotOrderRequired);

        return enumerable
            .Snapshot(predicate: predicate)
            .OrderBy(order)
            .ToArray();
    }
}