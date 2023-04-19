namespace MooVC.Threading;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Represents a coordinator, which is a component that is responsible for managing access to resources based on context specific metadata.
/// Coordination reduces contention by ensuring mutual exclusivity is only applied by type specific context metadata, rather than by type.
/// It is essentially the difference between locking a database table or locking a single row.
/// </summary>
/// <typeparam name="T">The type to which the context applies.</typeparam>
public interface ICoordinator<T>
    : IDisposable
    where T : notnull
{
    /// <summary>
    /// Asynchronously applies coordination in the specified context.
    /// </summary>
    /// <param name="context">The context in which coordination is to be applied.</param>
    /// <param name="timeout">A timeout that specifies how long the operation should wait for coordination to be granted.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// The result of the task is metadata relating to the mutual exclusive access granted by the coordinator in the specified context.
    /// </returns>
    Task<ICoordinationContext<T>> ApplyAsync(T context, TimeSpan? timeout = default, CancellationToken cancellationToken = default);
}