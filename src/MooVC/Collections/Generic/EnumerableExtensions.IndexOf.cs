namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
    private const int Default = -1;

    /// <summary>
    /// Returns the index of the first element in an enumerable sequence that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="enumeration"/>.</typeparam>
    /// <param name="enumeration">The sequence to search for an element that satisfies the condition.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// The index of the first element in the sequence that satisfies the condition, or -1 if no such element is found.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="predicate"/> is null.
    /// </exception>
    public static int IndexOf<T>(this IEnumerable<T>? enumeration, Func<T, bool> predicate)
    {
        if (enumeration is null)
        {
            return Default;
        }

        _ = IsNotNull(predicate, message: EnumerableExtensionsIndexOfPredicateRequired);

        return enumeration
            .Select((item, index) => new { Index = index, Item = item })
            .Where(item => predicate(item.Item))
            .Select(item => item.Index)
            .FirstOrDefault(Default);
    }
}