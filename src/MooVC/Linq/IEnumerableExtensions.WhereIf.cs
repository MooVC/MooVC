namespace MooVC.Linq;

using System.Diagnostics.CodeAnalysis;
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
    /// Filters a sequence of values based on a predicate if a specified condition is true.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumeration" />.</typeparam>
    /// <param name="enumeration">The sequence of values to filter.</param>
    /// <param name="isApplicable">A boolean value indicating whether to apply the filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>An <see cref="IEnumerable{T}" /> that contains elements from the input sequence that satisfy the condition.</returns>
    /// <remarks>
    /// If <paramref name="enumeration" /> is null and <paramref name="isApplicable" /> is true, an exception is thrown.
    /// If <paramref name="isApplicable" /> is false, the input sequence is returned unchanged.
    /// </remarks>
#if NET6_0_OR_GREATER
    [return: NotNullIfNotNull(nameof(enumeration))]
#endif
    public static IEnumerable<T>? WhereIf<T>(this IEnumerable<T>? enumeration, bool isApplicable, Func<T, bool> predicate)
    {
        if (enumeration is null || !isApplicable)
        {
            return enumeration;
        }

        _ = Guard.Against.Null(predicate, message: WhereIfPredicateRequired);

        return enumeration.Where(predicate);
    }

    /// <summary>
    /// Filters a sequence of values based on a predicate if a specified condition is true.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumeration" />.</typeparam>
    /// <param name="enumeration">The sequence of values to filter.</param>
    /// <param name="condition">A function that returns a boolean value indicating whether to apply the filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>An <see cref="IEnumerable{T}" /> that contains elements from the input sequence that satisfy the condition.</returns>
    /// <remarks>
    /// If <paramref name="enumeration" /> is null and the result of <paramref name="condition" /> is true, an exception is thrown.
    /// If the result of <paramref name="condition" /> is false, the input sequence is returned unchanged.
    /// </remarks>
#if NET6_0_OR_GREATER
    [return: NotNullIfNotNull(nameof(enumeration))]
#endif
    public static IEnumerable<T>? WhereIf<T>(this IEnumerable<T>? enumeration, Func<bool> condition, Func<T, bool> predicate)
    {
        if (enumeration is null)
        {
            return enumeration;
        }

        _ = Guard.Against.Null(condition, message: WhereIfConditionRequired);

        return enumeration.WhereIf(condition(), predicate);
    }
}