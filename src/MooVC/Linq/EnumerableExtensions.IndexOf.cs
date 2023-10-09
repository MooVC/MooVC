namespace MooVC.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Linq.EnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    private const int Default = -1;

    /// <summary>
    /// Returns the index of the first element in an enumerable sequence that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumeration" />.</typeparam>
    /// <param name="enumeration">The sequence to search for an element that satisfies the condition.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>The index of the first element in the sequence that satisfies the condition, or -1 if no such element is found.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="predicate" /> is <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int IndexOf<T>(this IEnumerable<T>? enumeration, Func<T, bool> predicate)
    {
        if (enumeration is null)
        {
            return Default;
        }

        _ = Guard.Against.Null(predicate, parameterName: nameof(predicate), message: IndexOfPredicateRequired);

        return enumeration
            .Select((item, index) => new { Index = index, Item = item })
            .Where(item => predicate(item.Item))
            .Select(item => item.Index)
            .DefaultIfEmpty(Default)
            .First();
    }
}