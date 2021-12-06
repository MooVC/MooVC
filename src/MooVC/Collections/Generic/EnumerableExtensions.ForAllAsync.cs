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
        public static async Task ForAllAsync<T>(this IEnumerable<T>? items, Func<T, Task> operation)
        {
            if (items is { })
            {
                _ = ArgumentNotNull(
                    operation,
                    nameof(operation),
                    EnumerableExtensionsForAllAsyncOperationRequired);

                var exceptions = new ConcurrentQueue<Exception>();

                IEnumerable<Task> operations = items
                    .Select(async item =>
                    {
                        try
                        {
                            await operation(item)
                                .ConfigureAwait(false);
                        }
                        catch (Exception ex)
                        {
                            exceptions.Enqueue(ex);
                        }
                    })
                    .ToArray();

                await Task
                    .WhenAll(operations)
                    .ConfigureAwait(false);

                if (exceptions.Any())
                {
                    throw new AggregateException(exceptions);
                }
            }
        }
    }
}