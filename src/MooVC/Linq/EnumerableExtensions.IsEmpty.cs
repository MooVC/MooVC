namespace MooVC.Linq;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Determines whether an enumerable sequence is empty or not.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the enumerable sequence.</typeparam>
    /// <param name="source">The enumerable sequence to check for emptiness.</param>
    /// <returns>True if the enumerable sequence is empty, or false if it is not.</returns>
    public static bool IsEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source)
    {
        if (source is null)
        {
            return true;
        }

        if (source.TryGetNonEnumeratedCount(out int count))
        {
            return count == 0;
        }

        return !source.Any();
    }
}