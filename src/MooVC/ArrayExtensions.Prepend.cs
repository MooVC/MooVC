namespace MooVC;

/// <summary>
/// Provides extensions relating to <see cref="Array" />.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// Prepends elements to the beginning of an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="source">The array to prepend to.</param>
    /// <param name="others">The elements to prepend to the array.</param>
    /// <returns>An array containing the original elements of the source array, with the other elements prepended at the beginning.</returns>
    public static T[] Prepend<T>(this T[]? source, params T[]? others)
    {
        return others.Append(source);
    }
}