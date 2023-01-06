namespace MooVC.Persistence;

using System;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Linq;
using static MooVC.Ensure;
using static MooVC.Persistence.Resources;

/// <summary>
/// Serves as an adapter, allowing for access to a resource via an alternative key than that applied by the implementing.
/// </summary>
/// <typeparam name="T">The type of the items in the store.</typeparam>
/// <typeparam name="TOutterKey">The type of the keys used to identify items in the store from an external perspective.</typeparam>
/// <typeparam name="TInnerKey">The type of the keys used to identify items in the store from an internal perspective.</typeparam>
public sealed class MappedStore<T, TOutterKey, TInnerKey>
    : IStore<T, TOutterKey>
{
    private readonly Func<TOutterKey, TInnerKey> innerMapping;
    private readonly Func<T, TInnerKey, TOutterKey> outterMapping;
    private readonly IStore<T, TInnerKey> store;

    /// <summary>
    /// Initializes a new instance of the <see cref="MappedStore{T, TOutterKey, TInnerKey}"/> class.
    /// </summary>
    /// <param name="innerMapping">A function that maps an external key to an internal key.</param>
    /// <param name="outterMapping">A function that maps an item and an internal key to an external key.</param>
    /// <param name="store">The store to wrap.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="innerMapping"/> is <see langword="null" />.
    /// <para>-or-</para>
    /// <paramref name="outterMapping"/> is <see langword="null" />.
    /// <para>-or-</para>
    /// <paramref name="store"/> is <see langword="null" />.
    /// </exception>
    public MappedStore(Func<TOutterKey, TInnerKey> innerMapping, Func<T, TInnerKey, TOutterKey> outterMapping, IStore<T, TInnerKey> store)
    {
        this.innerMapping = IsNotNull(innerMapping, message: MappedStoreInnerMappingRequired);
        this.outterMapping = IsNotNull(outterMapping, message: MappedStoreOutterMappingRequired);
        this.store = IsNotNull(store, message: MappedStoreStoreRequired);
    }

    /// <summary>
    /// Asynchronously creates a new item in the store and maps the internal key supplied to the expected external key.
    /// </summary>
    /// <param name="item">The item to create.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// The task result contains the mapped key of the newly created item.
    /// </returns>
    public async Task<TOutterKey> CreateAsync(T item, CancellationToken? cancellationToken = default)
    {
        TInnerKey innerKey = await store
            .CreateAsync(item, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return outterMapping(item, innerKey);
    }

    /// <summary>
    /// Asynchronously deletes an item from the store.
    /// </summary>
    /// <param name="item">The item to delete.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    public Task DeleteAsync(T item, CancellationToken? cancellationToken = default)
    {
        return store.DeleteAsync(item, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Asynchronously deletes an item from the store.
    /// </summary>
    /// <param name="outterKey">The external key that identifies the item to delete.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    public Task DeleteAsync(TOutterKey outterKey, CancellationToken? cancellationToken = default)
    {
        TInnerKey innerKey = innerMapping(outterKey);

        return store.DeleteAsync(innerKey, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves an item from the store.
    /// </summary>
    /// <param name="outterKey">The external key that identifies the item to retrieve.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// The task result contains the item with the specified <paramref name="outterKey"/>, or null if no such item exists.
    /// </returns>
    public Task<T?> GetAsync(TOutterKey outterKey, CancellationToken? cancellationToken = default)
    {
        TInnerKey innerKey = innerMapping(outterKey);

        return store.GetAsync(innerKey, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves item from the store, and optionally applies <paramref name="paging"/>.
    /// </summary>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <param name="paging">Optional paging instructions to be applied to the results.</param>
    /// <returns>
    /// A <see cref="Task"/> that represents the asynchronous operation.
    /// The task result contains paging instructions for the matching items.
    /// </returns>
    public Task<PagedResult<T>> GetAsync(CancellationToken? cancellationToken = default, Paging? paging = default)
    {
        return store.GetAsync(cancellationToken: cancellationToken, paging: paging);
    }

    /// <summary>
    /// Asynchronously updates an existing item within the store.
    /// </summary>
    /// <param name="item">The item to update.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    public Task UpdateAsync(T item, CancellationToken? cancellationToken = default)
    {
        return store.UpdateAsync(item, cancellationToken: cancellationToken);
    }
}