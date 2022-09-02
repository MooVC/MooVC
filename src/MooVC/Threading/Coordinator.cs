namespace MooVC.Threading;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using static System.String;
using static MooVC.Threading.Resources;

public sealed class Coordinator<T>
    : ICoordinator<T>
    where T : notnull
{
    public const string NumberFormat = "X";

    private readonly ConcurrentDictionary<string, SemaphoreSlim> contexts = new();
    private readonly TimeSpan? @default;

    public Coordinator(TimeSpan? @default = default)
    {
        this.@default = @default;
    }

    public async Task<ICoordinationContext<T>> ApplyAsync(T context, CancellationToken? cancellationToken = default, TimeSpan? timeout = default)
    {
        context = context ?? throw new ArgumentNullException(nameof(context), CoordinatorApplyAsyncContextRequired);
        timeout ??= @default;

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

    private static string GetKey(T context)
    {
        string? key = default;

        if (context is ICoordinatable<T> coordinatable)
        {
            key = coordinatable
                .GetKey()
                .ToString();
        }

        if (IsNullOrWhiteSpace(key))
        {
            return context
                .GetHashCode()
                .ToString(NumberFormat);
        }

        return key;
    }
}