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
    private readonly SemaphoreSlim mutex = new(1, 1);
    private T? resource;

    public Initializer(Func<CancellationToken, Task<T>> initializer)
    {
        this.initializer = IsNotNull(initializer, message: InitializerInitializerRequired);
    }

    public bool IsInitialized { get; private set; }

    public async Task<T> InitializeAsync(CancellationToken? cancellationToken = default)
    {
        if (!IsInitialized)
        {
            cancellationToken = cancellationToken.GetValueOrDefault();

            await mutex.WaitAsync(cancellationToken.Value);

            try
            {
                if (!IsInitialized)
                {
                    resource = await initializer(cancellationToken.Value);

                    if (resource is null)
                    {
                        throw new InvalidOperationException(InitializerInitializeAsyncResourceRequired);
                    }

                    IsInitialized = true;
                }
            }
            finally
            {
                _ = mutex.Release();
            }
        }

        return resource!;
    }
}