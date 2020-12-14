namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static void ForAll<T>(this IEnumerable<T>? items, Action<T> action)
        {
            if (items is { })
            {
                ArgumentNotNull(action, nameof(action), EnumerableExtensionsForAllActionRequired);

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

                if (exceptions.Any())
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}
