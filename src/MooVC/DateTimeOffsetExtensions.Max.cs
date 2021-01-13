namespace MooVC
{
    using System;

    public static partial class DateTimeOffsetExtensions
    {
        public static DateTimeOffset Max(this DateTimeOffset first, DateTimeOffset second)
        {
            return first > second
                ? first
                : second;
        }
    }
}