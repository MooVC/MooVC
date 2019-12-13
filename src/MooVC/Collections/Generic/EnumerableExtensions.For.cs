namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        public static void For<T>(this IEnumerable<T>? items, Action<int, T> action)
        {
            if (items is { })
            {
                int index = 0;

                foreach (T item in items)
                {
                    action(index++, item);
                }
            }
        }
    }
}