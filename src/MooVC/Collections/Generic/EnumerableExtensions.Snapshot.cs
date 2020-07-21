namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        public static T[] Snapshot<T>(this IEnumerable<T>? enumerable)
        {
            return enumerable?.ToArray() ?? new T[0];
        }

        public static T[] Snapshot<T, TKey>(this IEnumerable<T>? enumerable, Func<T, TKey> order)
        {
            return enumerable
                .Snapshot()
                .OrderBy(order)
                .ToArray();
        }
    }
}