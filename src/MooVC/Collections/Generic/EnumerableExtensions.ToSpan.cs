namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;

public static partial class EnumerableExtensions
{
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