namespace MooVC.Threading;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using static System.String;
using static MooVC.Threading.Resources;

public sealed class Coordinator
    : ICoordinator
{
    private readonly ConcurrentDictionary<string, SemaphoreSlim> contexts = new();

    public async Task<ICoordinationContext<T>> ApplyAsync<T>(T context, CancellationToken? cancellationToken = default, TimeSpan? timeout = default)
        where T : notnull
    {
        context = context ?? throw new ArgumentNullException(nameof(context), CoordinatorApplyAsyncContextRequired);

        string key = GetKey(context);
        SemaphoreSlim semaphore = contexts.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));

        timeout ??= Timeout.InfiniteTimeSpan;
        cancellationToken = cancellationToken.GetValueOrDefault();

        bool isSuccessful = await semaphore.WaitAsync(timeout.Value, cancellationToken.Value);

        if (!isSuccessful)
        {
            throw new TimeoutException(Format(CoordinatorApplyAsyncTimeout, context));
        }

        return new CoordinationContext<T>(context, semaphore);
    }

    private static string GetKey<T>(T context)
        where T : notnull
    {
        if (context is ICoordinatable coordinatable)
        {
            return coordinatable.GetKey();
        }

        return $"{context.GetType().FullName}_{context.GetHashCode()}";
    }
}