﻿namespace MooVC;

using System;

public static partial class DateTimeOffsetExtensions
{
    /// <summary>
    /// Returns the maximum of two dates.
    /// </summary>
    /// <param name="first">The first date to compare.</param>
    /// <param name="second">The second date to compare.</param>
    /// <returns>The later of the two dates.</returns>
    public static DateTimeOffset Max(this DateTimeOffset first, DateTimeOffset second)
    {
        return first.Ticks > second.Ticks
            ? first
            : second;
    }
}