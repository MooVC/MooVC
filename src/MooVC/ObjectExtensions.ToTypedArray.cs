﻿namespace MooVC;

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
}