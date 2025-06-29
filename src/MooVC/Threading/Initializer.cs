namespace MooVC.Threading;

using Ardalis.GuardClauses;
using static MooVC.Threading.Initializer_Resources;

/// <summary>
/// Provides support for asynchronous lazy initialization of a resource.
/// </summary>
/// <typeparam name="T">The type of the resource to be initialized.</typeparam>
public sealed class Initializer<T>
    where T : notnull
{
    private readonly Func<CancellationToken, Task<T>> _initializer;
    private readonly Lazy<SemaphoreSlim> _mutex = new(() => new(1, 1));
    private T? _resource;
    private int _waiting;

    /// <summary>
    /// Initializes a new instance of the <see cref="Initializer{T}" /> class.
    /// </summary>
    /// <param name="initializer">A function that initializes the resource.</param>
    public Initializer(Func<CancellationToken, Task<T>> initializer)
    {
        _initializer = Guard.Against.Null(initializer, message: InitializerRequired);
    }

    /// <summary>
    /// Gets a value indicating whether the resource has been initialized.
    /// </summary>
    /// <value>
    /// <c>true</c> if the resource has been initialized; otherwise, <c>false</c>.
    /// </value>
    public bool IsInitialized { get; private set; }

    private SemaphoreSlim Mutex => _mutex.Value;

    /// <summary>
    /// Asynchronously initializes the resource and coordinates access to it.
    /// </summary>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The result of the task is the initialized resource.
    /// </returns>
    public async Task<T> Initialize(CancellationToken cancellationToken)
    {
        if (!IsInitialized)
        {
            int remaining;

            _ = Interlocked.Increment(ref _waiting);

            try
            {
                await Mutex.WaitAsync(cancellationToken);
                await PerformInitialize(cancellationToken);
            }
            finally
            {
                remaining = Interlocked.Decrement(ref _waiting);

                _ = Mutex.Release();
            }

            if (remaining == 0)
            {
                Mutex.Dispose();
            }
        }

        return _resource!;
    }

    private async Task PerformInitialize(CancellationToken cancellationToken)
    {
        if (!IsInitialized)
        {
            _resource = await _initializer(cancellationToken)
                .ConfigureAwait(false);

            if (_resource is null)
            {
                throw new InvalidOperationException(InitializeAsyncResourceRequired);
            }

            IsInitialized = true;
        }
    }
}