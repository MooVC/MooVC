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
    /// Extends an array by appending the elements of another array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the arrays.</typeparam>
    /// <param name="source">The array to extend.</param>
    /// <param name="other">The array containing the elements to append to the source array.</param>
    /// <returns>An array containing the original elements of the source array, with the elements of the other array appended at the end.</returns>
    public static T[] Extend<T>(this T[]? source, T[]? other)
    {
        return Enumerable.ToArray(source.Combine(other));
    }
}