namespace MooVC
{
    using System;

    public static partial class DateTimeExtensions
    {
        public static DateTime Max(this DateTime first, DateTime second)
        {
            double value = Math.Max(first.ToOADate(), second.ToOADate());

            return DateTime.FromOADate(value);
        }
    }
}