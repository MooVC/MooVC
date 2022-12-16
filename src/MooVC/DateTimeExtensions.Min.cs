namespace MooVC;

using System;

/// <summary>
/// Provides the Min extension for <see cref="DateTime"/>.
/// </summary>
public static partial class DateTimeExtensions
{
    /// <summary>
    /// Returns the minimum of two dates.
    /// </summary>
    /// <param name="first">The first date to compare.</param>
    /// <param name="second">The second date to compare.</param>
    /// <returns>The earlier of the two dates.</returns>
    public static DateTime Min(this DateTime first, DateTime second)
    {
        return first.Ticks > second.Ticks
            ? second
            : first;
    }
}