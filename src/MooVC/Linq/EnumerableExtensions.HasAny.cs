namespace MooVC.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Ardalis.GuardClauses;
using static MooVC.Linq.EnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Determines whether an enumerable sequence is initialized and contains elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable sequence.</typeparam>
    /// <param name="source">The enumerable sequence to check for elements.</param>
    /// <returns>True if the enumerable sequence is populated with at least one element, or false if it is empty or null.</returns>
#if NET6_0_OR_GREATER
    public static bool HasAny<T>([NotNullWhen(true)] this IEnumerable<T>? source)
#else
    public static bool HasAny<T>(this IEnumerable<T>? source)
#endif
    {
        return !source.IsNullOrEmpty();
    }

    /// <summary>
    /// Determines whether any elements of an enumerable sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable sequence.</typeparam>
    /// <param name="source">The enumerable sequence to check for elements that satisfy the condition.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// True if any elements in the enumerable sequence satisfy the condition, or false if none of the elements do or the sequence is empty or null.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate" /> is null.</exception>
#if NET6_0_OR_GREATER
    public static bool HasAny<T>([NotNullWhen(true)] this IEnumerable<T>? source, Func<T, bool> predicate)
#else
    public static bool HasAny<T>(this IEnumerable<T>? source, Func<T, bool> predicate)
#endif
    {
        _ = Guard.Against.Null(predicate, parameterName: nameof(predicate), message: HasAnyPredicateRequired);

        return source is not null && source.Any(predicate);
    }
}