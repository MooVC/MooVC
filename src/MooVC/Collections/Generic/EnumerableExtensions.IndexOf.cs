namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Linq;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        private const int Default = -1;

        public static int IndexOf<T>(this IEnumerable<T>? enumeration, Func<T, bool> predicate)
        {
            if (enumeration is null)
            {
                return Default;
            }

            ArgumentNotNull(predicate, nameof(predicate), EnumerableExtensionsIndexOfPredicateRequired);

            return enumeration
                .Select((item, index) => new { Index = index, Item = item })
                .Where(item => predicate(item.Item))
                .Select(item => item.Index)
                .DefaultIfEmpty(Default)
                .First();
        }
    }
}