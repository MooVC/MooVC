namespace MooVC.Threading;

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Collections.Generic;
using static System.String;
using static MooVC.Threading.Resources;

public sealed class Coordinator<T>
    : ICoordinator<T>,
      IDisposable
    where T : notnull
{
    public const string NumberFormat = "X";

    private readonly ConcurrentDictionary<string, SemaphoreSlim> contexts = new();
    private readonly TimeSpan? @default;
    private bool isDisposed;

    public Coordinator(TimeSpan? @default = default)
    {
        this.@default = @default;
    }

    public async Task<ICoordinationContext<T>> ApplyAsync(T context, CancellationToken? cancellationToken = default, TimeSpan? timeout = default)
    {
        if (isDisposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }

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

    public void Dispose()
    {
        Dispose(isDisposing: true);

        GC.SuppressFinalize(this);
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

    private void Dispose(bool isDisposing)
    {
        if (!isDisposed)
        {
            if (isDisposing)
            {
                contexts.Values.ForAll(semaphore => semaphore.Dispose());
            }

            isDisposed = true;
        }
    }
}