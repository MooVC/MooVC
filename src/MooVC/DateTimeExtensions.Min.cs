namespace MooVC;

using System;

public static partial class DateTimeExtensions
{
    public static DateTime Min(this DateTime first, DateTime second)
    {
        return first > second
            ? second
            : first;
    }
}