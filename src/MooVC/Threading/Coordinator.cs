namespace MooVC.Threading;

using System.Collections.Concurrent;
using MooVC.Linq;
using static MooVC.Threading.Coordinator_Resources;

/// <summary>
/// Represents a coordinator that manages access to resources based on context specific string, provided via the GetKey method for the
/// <see cref="ICoordinatable" /> implementation of the context instance provided, or via its hashcode.
/// </summary>
/// <typeparam name="T">The type to which the context applies.</typeparam>
public sealed class Coordinator<T>
    : ICoordinator<T>
    where T : notnull
{
    private const string NumberFormat = "X";

    private readonly ConcurrentDictionary<string, SemaphoreSlim> contexts = new();
    private readonly TimeSpan? @default;
    private bool isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Coordinator{T}" /> class.
    /// </summary>
    /// <param name="default">
    /// The duration to wait for coordination to be granted if no duration has been explicitly specified in the context of the request.
    /// </param>
    public Coordinator(TimeSpan? @default = default)
    {
        this.@default = @default;
    }

    /// <summary>
    /// Asynchronously applies coordination in the specified context.
    /// </summary>
    /// <param name="context">The context in which coordination is to be applied.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <param name="timeout">A timeout that specifies how long the operation should wait for coordination to be granted.</param>
    /// <returns>
    /// A <see cref="Task{TResult}" /> that represents the asynchronous operation.
    /// The result of the task is metadata relating to the mutual exclusive access granted by the coordinator in the specified context.
    /// </returns>
    public async Task<ICoordinationContext<T>> Apply(T context, CancellationToken cancellationToken, TimeSpan? timeout = default)
    {
        if (isDisposed)
        {
            throw new ObjectDisposedException(GetType().FullName);
        }

        context = context ?? throw new ArgumentNullException(nameof(context), ApplyAsyncContextRequired);
        timeout ??= @default;

        string key = GetKey(context);
        SemaphoreSlim semaphore = contexts.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));

        timeout ??= Timeout.InfiniteTimeSpan;

        bool isSuccessful = await semaphore.WaitAsync(timeout.Value, cancellationToken);

        if (!isSuccessful)
        {
            throw new TimeoutException(ApplyAsyncTimeout.Format(context));
        }

        return new CoordinationContext<T>(context, semaphore);
    }

    /// <summary>
    /// Disposes all coordination resources for every context encountered during its lifecycle, including those that are currently being held.
    /// </summary>
    public void Dispose()
    {
        Dispose(isDisposing: true);

        GC.SuppressFinalize(this);
    }

    private static string GetKey(T context)
    {
        string? key = default;

        if (context is ICoordinatable coordinatable)
        {
            key = coordinatable.GetKey();
        }

        if (string.IsNullOrWhiteSpace(key))
        {
            return context
                .GetHashCode()
                .ToString(NumberFormat);
        }

        return key!;
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