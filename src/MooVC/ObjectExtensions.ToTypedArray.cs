namespace MooVC;

using System.Runtime.CompilerServices;

/// <summary>
/// Provides extensions relating to object.
/// </summary>
public static partial class ObjectExtensions
{
    /// <summary>
    /// Returns an array containing the single specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned in the array.</typeparam>
    /// <param name="value">The value to be returned in the array.</param>
    /// <returns>An array containing the single specified value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToTypedArray<T>(this T value)
    {
        return [value];
    }

    /// <summary>
    /// Returns the provided array without modification.
    /// </summary>
    /// <typeparam name="T">The element type of the array.</typeparam>
    /// <param name="values">The array to be returned.</param>
    /// <returns>The same array provided in <paramref name="values"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T[] ToTypedArray<T>(this T[] values)
    {
        return values;
    }
}