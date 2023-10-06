namespace MooVC;

using System.Linq;
using MooVC.Collections.Generic;
using MooVC.Linq;

/// <summary>
/// Provides extensions relating to <see cref="Array" />.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// Appends an element to the end of an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="source">The array to append to.</param>
    /// <param name="other">The element to append to the array.</param>
    /// <returns>An array containing the original elements of the source array, with the other element appended at the end.</returns>
    public static T[] Append<T>(this T[]? source, T other)
    {
        return Enumerable.ToArray(source.Combine<T>(other));
    }
}