namespace MooVC.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Determines whether an enumerable sequence is not empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable sequence.</typeparam>
    /// <param name="source">The enumerable sequence to check for emptiness.</param>
    /// <returns>True if the enumerable sequence is not empty, or false if it is empty or null.</returns>
#if NET6_0_OR_GREATER
    public static bool SafeAny<T>([NotNullWhen(true)] this IEnumerable<T>? source)
    {
        return !source.IsEmpty();
    }
#else
    public static bool SafeAny<T>(this IEnumerable<T>? source)
    {
        return !source.IsEmpty();
    }
#endif

    /// <summary>
    /// Determines whether any elements of an enumerable sequence satisfy a condition.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable sequence.</typeparam>
    /// <param name="source">The enumerable sequence to check for elements that satisfy the condition.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// True if any elements in the enumerable sequence satisfy the condition, or false if none of the elements do or the sequence is empty or null.
    /// </returns>
#if NET6_0_OR_GREATER
    public static bool SafeAny<T>([NotNullWhen(true)] this IEnumerable<T>? source, Func<T, bool> predicate)
    {
        return PerformSafeAny(source, predicate);
    }
#else
    public static bool SafeAny<T>(this IEnumerable<T>? source, Func<T, bool> predicate)
    {
        return PerformSafeAny(source, predicate);
    }
#endif

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool PerformSafeAny<T>(this IEnumerable<T>? source, Func<T, bool> predicate)
    {
        return source is not null && source.Any(predicate);
    }
}