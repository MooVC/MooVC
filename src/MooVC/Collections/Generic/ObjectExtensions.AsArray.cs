﻿namespace MooVC.Collections.Generic;

public static partial class ObjectExtensions
{
    /// <summary>
    /// Returns an array containing the single specified value.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned in the array.</typeparam>
    /// <param name="value">The value to be returned in the array.</param>
    /// <returns>An array containing the single specified value.</returns>
    public static T[] AsArray<T>(this T value)
    {
        return new[] { value };
    }
}