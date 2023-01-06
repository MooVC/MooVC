namespace MooVC.Persistence;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Facilitates synchronous implementation of a storage location for a stream of indexed events.
/// </summary>
/// <typeparam name="T">The type of the events within the stream.</typeparam>
/// <typeparam name="TIndex">The type of index for the events.</typeparam>
public abstract class SynchronousEventStore<T, TIndex>
    : IEventStore<T, TIndex>
    where T : class
{
    /// <summary>
    /// Asynchronously retrieves the event with the specified <paramref name="index"/> from the event store.
    /// </summary>
    /// <param name="index">The index of the event to retrieve.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// The task result contains the event with the specified <paramref name="index"/>, or null if no such event exists.
    /// </returns>
    public virtual Task<T?> GetAsync(TIndex index, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformGet(index));
    }

    /// <summary>
    /// Asynchronously inserts the specified <paramref name="event"/> into the event store.
    /// </summary>
    /// <param name="event">The event to insert.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// The task result contains the index of the newly inserted event.
    /// </returns>
    public virtual Task<TIndex> InsertAsync(T @event, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformInsert(@event));
    }

    /// <summary>
    /// Asynchronously retrieves events starting from after the specified <paramref name="lastIndex"/> and totalling
    /// no more than <paramref name="numberToRead"/>.
    /// </summary>
    /// <param name="lastIndex">The index of the previous event read from the stream.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <param name="numberToRead">The number of events to read from the stream following <paramref name="lastIndex"/>.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// The task result contains the list of matching events.
    /// </returns>
    public virtual Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, CancellationToken? cancellationToken = default, ushort numberToRead = 10)
    {
        return Task.FromResult(PerformRead(lastIndex, numberToRead: numberToRead));
    }

    /// <summary>
    /// Facilitates synchronous implementation of event retrieval with the specified <paramref name="index"/> from the event store.
    /// </summary>
    /// <param name="index">The index of the event to retrieve.</param>
    /// <returns>The event with the specified <paramref name="index"/>, or null if no such event exists.</returns>
    protected abstract T? PerformGet(TIndex index);

    /// <summary>
    /// Facilitates synchronous implementation of event insertion into the event store.
    /// </summary>
    /// <param name="event">The event to insert.</param>
    /// <returns>The index of the newly inserted event.</returns>
    protected abstract TIndex PerformInsert(T @event);

    /// <summary>
    /// Facilitates synchronous implementation event retrieval starting from after the specified
    /// <paramref name="lastIndex"/> and totalling no more than <paramref name="numberToRead"/>.
    /// </summary>
    /// <param name="lastIndex">The index of the previous event read from the stream.</param>
    /// <param name="numberToRead">The number of events to read from the stream following <paramref name="lastIndex"/>.</param>
    /// <returns>The list of matching events.</returns>
    protected abstract IEnumerable<T> PerformRead(TIndex lastIndex, ushort numberToRead = 10);
}