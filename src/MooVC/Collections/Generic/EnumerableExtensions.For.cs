namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static void For<T>(this IEnumerable<T>? items, Action<int, T> action)
        {
            if (items is { })
            {
                ArgumentNotNull(action, nameof(action), EnumerableExtensionsActionRequired);

                int index = 0;

                foreach (T item in items)
                {
                    action(index++, item);
                }
            }
        }
    }
}