namespace MooVC.Linq;

using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Linq.IEnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Returns a snapshot of an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumerable" />.</typeparam>
    /// <param name="enumerable">The sequence to take a snapshot of.</param>
    /// <param name="predicate">
    /// An optional function to test each element for a condition.
    /// If provided, only elements that satisfy the condition will be included in the snapshot.
    /// </param>
    /// <returns>An array that contains the elements of the snapshot.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArrayOrEmpty<T>(this IEnumerable<T>? enumerable, Func<T, bool>? predicate = default)
    {
        if (enumerable is null)
        {
            return [];
        }

        return enumerable
            .WhereIf(predicate is not null, predicate!)
            .ToArray();
    }

    /// <summary>
    /// Returns a snapshot of an enumerable sequence, ordered by the given key.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumerable" />.</typeparam>
    /// <typeparam name="TKey">The type of the order key.</typeparam>
    /// <param name="enumerable">The sequence to take a snapshot of.</param>
    /// <param name="order">The function to use to extract the key used to order the snapshot.</param>
    /// <param name="predicate">
    /// An optional function to test each element for a condition.
    /// If provided, only elements that satisfy the condition will be included in the snapshot.
    /// </param>
    /// <returns>An array that contains the elements of the snapshot, ordered by the given key.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToArrayOrEmpty<T, TKey>(this IEnumerable<T>? enumerable, Func<T, TKey> order, Func<T, bool>? predicate = default)
    {
        _ = Guard.Against.Null(order, message: ToArrayOrEmptyOrderRequired);

        return enumerable
            .ToArrayOrEmpty(predicate: predicate)
            .OrderBy(order)
            .ToArray();
    }
}