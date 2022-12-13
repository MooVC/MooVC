namespace MooVC.Collections.Generic;

using System.Collections.Generic;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Returns an enumerable sequence containing the single specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned in the sequence.</typeparam>
    /// <param name="value">The value to be returned in the sequence.</param>
    /// <returns>An enumerable sequence containing the single specified value.</returns>
    public static IEnumerable<T> AsEnumerable<T>(this T value)
    {
        yield return value;
    }
}