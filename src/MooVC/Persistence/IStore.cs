namespace MooVC.Persistence;

using System.Threading;
using System.Threading.Tasks;
using MooVC.Linq;

/// <summary>
/// Represents a generic store for persisted items.
/// </summary>
/// <typeparam name="T">The type of the items in the store.</typeparam>
/// <typeparam name="TKey">The type of the keys used to identify items in the store.</typeparam>
public interface IStore<T, TKey>
{
    /// <summary>
    /// Asynchronously creates a new item in the store.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task" /> that represents the asynchronous operation.
    /// The task result contains the key of the newly created item.
    /// </returns>
    Task<TKey> CreateAsync(T item, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously deletes an item from the store.
    /// </summary>
    /// <param name="item">The item to delete.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
    Task DeleteAsync(T item, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously deletes an item from the store.
    /// </summary>
    /// <param name="key">The key that identifies the item to delete.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
    Task DeleteAsync(TKey key, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves an item from the store.
    /// </summary>
    /// <param name="key">The key that identifies the item to retrieve.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task" /> that represents the asynchronous operation.
    /// The task result contains the item with the specified <paramref name="key" />, or null if no such item exists.
    /// </returns>
    Task<T?> GetAsync(TKey key, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously retrieves items from the store, and optionally applies <paramref name="paging" />.
    /// </summary>
    /// <param name="paging">Optional paging instructions to be applied to the results.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task" /> that represents the asynchronous operation.
    /// The task result contains paging instructions for the matching items.
    /// </returns>
    Task<PagedResult<T>> GetAsync(Paging? paging = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously updates an existing item within the store.
    /// </summary>
    /// <param name="item">The item to update.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task" /> that represents the asynchronous operation.</returns>
    Task UpdateAsync(T item, CancellationToken cancellationToken);
}