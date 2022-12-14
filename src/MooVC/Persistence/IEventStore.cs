namespace MooVC.Persistence;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Linq;

/// <summary>
/// Represents a storage location for a stream of indexed events.
/// </summary>
/// <typeparam name="T">The type of the events within the stream.</typeparam>
/// <typeparam name="TIndex">The type of index for the events.</typeparam>
public interface IEventStore<T, TIndex>
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
    Task<T?> GetAsync(TIndex index, CancellationToken? cancellationToken = default);

    /// <summary>
    /// Asynchronously inserts the specified <paramref name="event"/> into the event store.
    /// </summary>
    /// <param name="event">The event to insert.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> that represents the asynchronous operation.
    /// The task result contains the index of the newly inserted event.
    /// </returns>
    Task<TIndex> InsertAsync(T @event, CancellationToken? cancellationToken = default);

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
    Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, CancellationToken? cancellationToken = default, ushort numberToRead = Paging.DefaultSize);
}