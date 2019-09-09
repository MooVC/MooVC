namespace MooVC.Linq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> enumeration, Func<T, bool> predicate)
        {
            return enumeration
                .Select((item, index) => new { Index = index, Item = item })
                .Where(item => predicate(item.Item))
                .Select(item => item.Index)
                .DefaultIfEmpty(-1)
                .First();
        }
    }
}