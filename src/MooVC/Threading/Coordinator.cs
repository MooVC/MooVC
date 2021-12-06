namespace MooVC.Threading
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using static System.String;
    using static MooVC.Ensure;
    using static MooVC.Threading.Resources;

    public static class Coordinator
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> contexts = new();

        public static async Task ApplyAsync(
            string context,
            Func<Task> operation,
            CancellationToken? cancellationToken = default,
            TimeSpan? timeout = default)
        {
            _ = ArgumentNotNullOrWhiteSpace(
                context,
                nameof(context),
                CoordinatorApplyAsyncContextRequired);

            _ = ArgumentNotNull(
                operation,
                nameof(operation),
                CoordinatorApplyAsyncOperationRequired);

            SemaphoreSlim semaphore = contexts.GetOrAdd(
                context,
                _ => new SemaphoreSlim(1, 1));

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