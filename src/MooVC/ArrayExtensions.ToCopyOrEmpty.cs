namespace MooVC;

using System.Runtime.CompilerServices;

/// <summary>
/// Provides extensions relating to <see cref="Array" />.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// Creates a snapshot copy of an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements within <paramref name="values" />.</typeparam>
    /// <param name="values">The array to copy.</param>
    /// <param name="predicate">
    /// An optional function to test each element for a condition.
    /// If provided, only elements that satisfy the condition will be included in the snapshot.
    /// </param>
    /// <returns>
    /// A new array that contains matching elements from <paramref name="values" />.
    /// Returns an empty array when <paramref name="values" /> is <see langword="null" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToCopyOrEmpty<T>(this T[]? values, Func<T, bool>? predicate = default)
    {
        if (values is null)
        {
            return [];
        }

        return values.ToCopy(predicate: predicate);
    }
}