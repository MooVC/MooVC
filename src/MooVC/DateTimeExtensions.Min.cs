namespace MooVC
{
    using System;

    public static partial class DateTimeExtensions
    {
        public static DateTime Min(this DateTime first, DateTime second)
        {
            double value = Math.Min(first.ToOADate(), second.ToOADate());

            return DateTime.FromOADate(value);
        }
    }
}