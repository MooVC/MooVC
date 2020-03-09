namespace MooVC.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        public static bool SafeAny<T>(this IEnumerable<T>? source)
        {
            return source is { }
                ? source.Any()
                : false;
        }

        public static bool SafeAny<T>(this IEnumerable<T>? source, Func<T, bool> predicate)
        {
            return source is { }
                ? source.Any(predicate)
                : false;
        }
    }
}
