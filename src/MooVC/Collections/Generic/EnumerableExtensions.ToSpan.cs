namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Converts an enumerable sequence to a <see cref="ReadOnlySpan{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="items"/>.</typeparam>
    /// <param name="items">The sequence of values to convert.</param>
    /// <returns>A <see cref="ReadOnlySpan{T}"/> that contains the elements from the input sequence.</returns>
    /// <remarks>
    /// If <paramref name="items"/> is null or empty, an empty <see cref="ReadOnlySpan{T}"/> is returned.
    /// Otherwise, the input sequence is first converted to an array, and then the array is wrapped in a <see cref="ReadOnlySpan{T}"/>.
    /// </remarks>
    public static ReadOnlySpan<T> ToSpan<T>(this IEnumerable<T>? items)
    {
        if (items is { })
        {
            T[] elements = items.ToArray();

            return new ReadOnlySpan<T>(elements);
        }

        return ReadOnlySpan<T>.Empty;
    }
}