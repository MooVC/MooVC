namespace MooVC.Threading;

using System;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Ensure;
using static MooVC.Threading.Resources;

public sealed class Initializer<T>
    where T : notnull
{
    private readonly Func<CancellationToken, Task<T>> initializer;
    private readonly Lazy<SemaphoreSlim> mutex = new(() => new(1, 1));
    private T? resource;
    private int waiting;

    public Initializer(Func<CancellationToken, Task<T>> initializer)
    {
        this.initializer = IsNotNull(initializer, message: InitializerInitializerRequired);
    }

    public bool IsInitialized { get; private set; }

    private SemaphoreSlim Mutex => mutex.Value;

    public async Task<T> InitializeAsync(CancellationToken? cancellationToken = default)
    {
        if (!IsInitialized)
        {
            int remaining;

            _ = Interlocked.Increment(ref waiting);

            try
            {
                cancellationToken = cancellationToken.GetValueOrDefault();

                await Mutex.WaitAsync(cancellationToken.Value);
                await PerformInitializeAsync(cancellationToken.Value);
            }
            finally
            {
                remaining = Interlocked.Decrement(ref waiting);

                _ = Mutex.Release();
            }

            if (remaining == 0)
            {
                Mutex.Dispose();
            }
        }

        return resource!;
    }

    private async Task PerformInitializeAsync(CancellationToken cancellationToken)
    {
        if (!IsInitialized)
        {
            resource = await initializer(cancellationToken)
                .ConfigureAwait(false);

            if (resource is null)
            {
                throw new InvalidOperationException(InitializerInitializeAsyncResourceRequired);
            }

            IsInitialized = true;
        }
    }
}