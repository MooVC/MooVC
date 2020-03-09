namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        private const int Default = -1;

        public static int IndexOf<T>(this IEnumerable<T>? enumeration, Func<T, bool> predicate)
        {
            if (enumeration is null)
            {
                return Default;
            }

            return enumeration
                .Select((item, index) => new { Index = index, Item = item })
                .Where(item => predicate(item.Item))
                .Select(item => item.Index)
                .DefaultIfEmpty(Default)
                .First();
        }
    }
}