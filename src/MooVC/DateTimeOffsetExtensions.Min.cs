namespace MooVC
{
    using System;

    public static partial class DateTimeOffsetExtensions
    {
        public static DateTimeOffset Min(this DateTimeOffset first, DateTimeOffset second)
        {
            return first > second
                ? second
                : first;
        }
    }
}