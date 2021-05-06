namespace MooVC
{
    using System;

    public static partial class DateTimeExtensions
    {
        public static DateTime Max(this DateTime first, DateTime second)
        {
            return first > second
                ? first
                : second;
        }
    }
}