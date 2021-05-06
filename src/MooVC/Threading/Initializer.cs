namespace MooVC.Threading
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using static MooVC.Ensure;
    using static MooVC.Threading.Resources;

    public sealed class Initializer<T>
        where T : notnull
    {
        private readonly Func<Task<T>> initializer;
        private readonly SemaphoreSlim mutex = new(1, 1);
        private T? resource;

        public Initializer(Func<Task<T>> initializer)
        {
            ArgumentNotNull(initializer, nameof(initializer), InitializerInitializerRequired);

            this.initializer = initializer;
        }

        public bool IsInitialized { get; private set; }

        public async Task<T> InitializeAsync(CancellationToken? cancellationToken = default)
        {
            if (!IsInitialized)
            {
                await mutex.WaitAsync(cancellationToken ?? CancellationToken.None);

                try
                {
                    if (!IsInitialized)
                    {
                        resource = await initializer();

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
}