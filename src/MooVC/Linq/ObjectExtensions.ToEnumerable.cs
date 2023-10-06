namespace MooVC.Linq;

using System.Collections.Generic;

/// <summary>
/// Provides extensions relating to object.
/// </summary>
public static partial class ObjectExtensions
{
    /// <summary>
    /// Returns an enumerable sequence containing the single specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned in the sequence.</typeparam>
    /// <param name="value">The value to be returned in the sequence.</param>
    /// <returns>An enumerable sequence containing the single specified value.</returns>
    public static IEnumerable<T> ToEnumerable<T>(this T value)
    {
        yield return value;
    }
}