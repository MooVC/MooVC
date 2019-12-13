namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static partial class EnumerableExtensions
    {
        public static void ForAll<T>(this IEnumerable<T> items, Action<T> action)
        {
            if (items != null)
            {
                var exceptions = new ConcurrentQueue<Exception>();

                _ = Parallel.ForEach(
                    items,
                    item =>
                    {
                        try
                        {
                            action(item);
                        }
                        catch (Exception ex)
                        {
                            exceptions.Enqueue(ex);
                        }
                    });

                if (exceptions.Count > 0)
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
