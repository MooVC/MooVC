namespace MooVC.Persistence;

using System.Threading;
using System.Threading.Tasks;
using MooVC.Linq;

/// <summary>
/// Facilitates synchronous implementation of a generic store for persisted items.
/// </summary>
/// <typeparam name="T">The type of the items in the store.</typeparam>
/// <typeparam name="TKey">The type of the keys used to identify items in the store.</typeparam>
public abstract class SynchronousStore<T, TKey>
    : IStore<T, TKey>
{
    /// <summary>
    /// Asynchronously creates a new item in the store.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// The task result contains the key of the newly created item.
    /// </returns>
    public virtual async Task<TKey> CreateAsync(T item, CancellationToken cancellationToken)
    {
        return await Task.FromResult(PerformCreate(item));
    }

    /// <summary>
    /// Asynchronously deletes an item from the store.
    /// </summary>
    /// <param name="item">The item to delete.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    public virtual Task DeleteAsync(T item, CancellationToken cancellationToken)
    {
        PerformDelete(item);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Asynchronously deletes an item from the store.
    /// </summary>
    /// <param name="key">The key that identifies the item to delete.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    public virtual Task DeleteAsync(TKey key, CancellationToken cancellationToken)
    {
        PerformDelete(key);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Asynchronously retrieves an item from the store.
    /// </summary>
    /// <param name="key">The key that identifies the item to retrieve.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// The task result contains the item with the specified <paramref name="key"/>, or null if no such item exists.
    /// </returns>
    public virtual Task<T?> GetAsync(TKey key, CancellationToken cancellationToken)
    {
        return Task.FromResult(PerformGet(key));
    }

    /// <summary>
    /// Asynchronously retrieves items from the store, and optionally applies <paramref name="paging"/>.
    /// </summary>
    /// <param name="paging">Optional paging instructions to be applied to the results.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// The task result contains paging instructions for the matching items.
    /// </returns>
    public virtual Task<PagedResult<T>> GetAsync(Paging? paging = default, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(PerformGet(paging: paging));
    }

    /// <summary>
    /// Asynchronously updates an existing item within the store.
    /// </summary>
    /// <param name="item">The item to update.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    public virtual Task UpdateAsync(T item, CancellationToken cancellationToken)
    {
        PerformUpdate(item);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Facilitates synchronous implementation of item creation in the store.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <returns>The key of the newly created item.</returns>
    protected abstract TKey PerformCreate(T item);

    /// <summary>
    /// Facilitates synchronous implementation of item deletion from the store.
    /// </summary>
    /// <param name="item">The item to delete.</param>
    protected abstract void PerformDelete(T item);

    /// <summary>
    /// Facilitates synchronous implementation of item deletion from the store.
    /// </summary>
    /// <param name="key">The key that identifies the item to delete.</param>
    protected abstract void PerformDelete(TKey key);

    /// <summary>
    /// Facilitates synchronous implementation of item retrieval from the store.
    /// </summary>
    /// <param name="key">The key that identifies the item to retrieve.</param>
    /// <returns>The item with the specified <paramref name="key"/>, or null if no such item exists.</returns>
    protected abstract T? PerformGet(TKey key);

    /// <summary>
    /// Facilitates synchronous implementation items retrieval from the store, and optionally applies <paramref name="paging"/>.
    /// </summary>
    /// <param name="paging">Optional paging instructions to be applied to the results.</param>
    /// <returns>Paging instructions for the matching items.</returns>
    protected abstract PagedResult<T> PerformGet(Paging? paging = default);

    /// <summary>
    /// Facilitates synchronous implementation of an update to an existing item within the store.
    /// </summary>
    /// <param name="item">The item to update.</param>
    protected abstract void PerformUpdate(T item);
}