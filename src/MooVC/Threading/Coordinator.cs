namespace MooVC.Threading
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using static System.String;
    using static MooVC.Ensure;
    using static MooVC.Threading.Resources;

    public sealed class Coordinator
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> contexts
            = new ConcurrentDictionary<string, SemaphoreSlim>();

        public static async Task ApplyAsync(
            string context,
            Func<Task> operation,
            CancellationToken? cancellationToken = default,
            TimeSpan? timeout = default)
        {
            ArgumentNotNullOrWhiteSpace(context, nameof(context), CoordinatorApplyAsyncContextRequired);
            ArgumentNotNull(operation, nameof(operation), CoordinatorApplyAsyncOperationRequired);

            SemaphoreSlim semaphore = contexts.GetOrAdd(context, _ => new SemaphoreSlim(1, 1));

            bool isSuccessful = await semaphore.WaitAsync(
                timeout ?? Timeout.InfiniteTimeSpan,
                cancellationToken ?? CancellationToken.None);

            if (isSuccessful)
            {
                try
                {
                    await operation();
                }
                finally
                {
                    _ = semaphore.Release();
                }
            }
            else
            {
                throw new TimeoutException(Format(CoordinatorApplyAsyncTimeout, context));
            }
        }
    }
}