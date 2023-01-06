namespace MooVC;

using System;

/// <summary>
/// Provides the Max extension for <see cref="DateTime"/>.
/// </summary>
public static partial class DateTimeExtensions
{
    /// <summary>
    /// Returns the maximum of two dates.
    /// </summary>
    /// <param name="first">The first date to compare.</param>
    /// <param name="second">The second date to compare.</param>
    /// <returns>The later of the two dates.</returns>
    public static DateTime Max(this DateTime first, DateTime second)
    {
        return first.Ticks > second.Ticks
            ? first
            : second;
    }
}