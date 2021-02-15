namespace MooVC.Threading
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using static MooVC.Ensure;
    using static MooVC.Threading.Resources;

    public sealed class Initializer<T>
        where T : class
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

                    if (resource is null)
                    {
                        try
                        {
                            mutex.EnterWriteLock();

                            resource = await initializer()
                                .ConfigureAwait(false);

                            IsInitialized = true;
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