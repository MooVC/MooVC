namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static T[] Snapshot<T>(this IEnumerable<T>? enumerable)
        {
            return enumerable?.ToArray() ?? Array.Empty<T>();
        }

        public static T[] Snapshot<T, TKey>(this IEnumerable<T>? enumerable, Func<T, TKey> order)
        {
            if (enumerable is { })
            {
                ArgumentNotNull(order, nameof(order), EnumerableExtensionsSnapshotOrderRequired);

                return enumerable
                    .OrderBy(order)
                    .ToArray();
            }

            return Array.Empty<T>();
        }
    }
}