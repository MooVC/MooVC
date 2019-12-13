namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public static partial class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T>? items, Action<T> action)
        {
            if (items is { })
            {
                foreach (T item in items)
                {
                    action(item);
                }
            }
        }
    }
}