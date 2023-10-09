namespace MooVC.Linq;

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
    /// <summary>
    /// Determines whether an enumerable sequence is empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable sequence.</typeparam>
    /// <param name="source">The enumerable sequence to check for emptiness.</param>
    /// <returns>True if the enumerable sequence has no elements, or false if it is populated with at least one element.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="source" /> is null.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEmpty<T>(this IEnumerable<T> source)
    {
        _ = Guard.Against.Null(source, parameterName: nameof(source), message: IsEmptySourceRequired);

#if NET6_0_OR_GREATER
        if (source.TryGetNonEnumeratedCount(out int count))
        {
            return count == 0;
        }
#endif

        return !source.Any();
    }
}