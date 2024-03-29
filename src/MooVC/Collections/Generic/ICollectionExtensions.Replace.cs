namespace MooVC.Collections.Generic;

using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Collections.Generic.ICollectionExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="ICollection{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the collection.</typeparam>
public static partial class ICollectionExtensions
{
    /// <summary>
    /// Clears the contents of the <paramref name="target" /> collection and replaces them with the elements from the <paramref name="items" />
    /// enumeration.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the collection.</typeparam>
    /// <param name="target">The collection in which the elements are to be replaced.</param>
    /// <param name="replacements">The elements to be inserted into the collection once the collection has been cleared.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="target" /> is <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Replace<T>(this ICollection<T> target, IEnumerable<T>? replacements)
    {
        _ = Guard.Against.Null(target, message: ReplaceTargetRequired);

        target.Clear();

        if (replacements is not null)
        {
            target.AddRange(replacements);
        }
    }
}