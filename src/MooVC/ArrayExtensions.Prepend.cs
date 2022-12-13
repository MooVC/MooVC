namespace MooVC;

using MooVC.Collections.Generic;

public static partial class ArrayExtensions
{
    /// <summary>
    /// Prepends an element to the beginning of an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="source">The array to prepend to.</param>
    /// <param name="other">The element to prepend to the array.</param>
    /// <returns>An array containing the original elements of the source array, with the other element prepended at the beginning.</returns>
    public static T[] Prepend<T>(this T[]? source, T other)
    {
        if (source is null)
        {
            return other.AsArray();
        }

        var destination = new T[source.Length + 1];

        Array.Copy(source, 0, destination, 1, source.Length);

        destination[0] = other;

        return destination;
    }
}