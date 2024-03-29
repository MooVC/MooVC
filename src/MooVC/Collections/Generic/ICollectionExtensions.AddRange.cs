namespace MooVC.Collections.Generic;

using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using MooVC.Linq;
using static MooVC.Collections.Generic.ICollectionExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="ICollection{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the collection.</typeparam>
public static partial class ICollectionExtensions
{
    /// <summary>
    /// Adds elements from the <paramref name="items" /> enumeration to the <paramref name="target" /> collection.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the collection.</typeparam>
    /// <param name="target">The collection to which the elements are inserted.</param>
    /// <param name="items">The items to be inserted into the collection.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="target" /> is <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void AddRange<T>(this ICollection<T> target, IEnumerable<T>? items)
    {
        _ = Guard.Against.Null(target, message: AddRangeTargetRequired);

        items.ForEach(target.Add);
    }
}