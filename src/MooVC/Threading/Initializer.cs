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
        private readonly ReaderWriterLockSlim mutex = new ReaderWriterLockSlim();
        private T? resource;

        public Initializer(Func<Task<T>> initializer)
        {
            ArgumentNotNull(initializer, nameof(initializer), InitializerInitializerRequired);

            this.initializer = initializer;
        }

        public bool IsInitialized { get; private set; }

        public async Task<T> InitializeAsync()
        {
            if (!IsInitialized)
            {
                try
                {
                    mutex.EnterUpgradeableReadLock();

                    if (!IsInitialized)
                    {
                        try
                        {
                            mutex.EnterWriteLock();

                            if (!IsInitialized)
                            {
                                resource = await initializer()
                                    .ConfigureAwait(false);

                                IsInitialized = resource is { };
                            }
                        }
                        finally
                        {
                            mutex.ExitWriteLock();
                        }
                    }
                }
                finally
                {
                    mutex.ExitUpgradeableReadLock();
                }
            }

            return resource!;
        }
    }
}