namespace MooVC;

using System.Runtime.CompilerServices;

/// <summary>
/// Provides extensions relating to <see cref="Array" />.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// Prepends one or more elements to the beginning of an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="source">The source array that receives the prepended values.</param>
    /// <param name="others">The values to place before the source items.</param>
    /// <returns>A new array containing <paramref name="others" /> followed by <paramref name="source" />.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] Prepend<T>(this T[]? source, params T[]? others)
    {
        return others.Append(source);
    }
}