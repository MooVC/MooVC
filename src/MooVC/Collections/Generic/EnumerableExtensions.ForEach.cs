namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T>? items, Action<T> action)
        {
            if (items is { })
            {
                _ = ArgumentNotNull(
                    action,
                    nameof(action),
                    EnumerableExtensionsActionRequired);

                foreach (T item in items)
                {
                    action(item);
                }
            }
        }
    }
}