namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static partial class EnumerableExtensions
    {
        public static void ForAll<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items != null)
            {
                _ = Parallel.ForEach(items, action);
            }
        }
    }
}
