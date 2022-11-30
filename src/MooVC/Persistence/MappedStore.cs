namespace MooVC.Persistence;

using System;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Linq;
using static MooVC.Ensure;
using static MooVC.Persistence.Resources;

public sealed class MappedStore<T, TOutterKey, TInnerKey>
    : IStore<T, TOutterKey>
{
    private readonly Func<TOutterKey, TInnerKey> innerMapping;
    private readonly Func<T, TInnerKey, TOutterKey> outterMapping;
    private readonly IStore<T, TInnerKey> store;

    public MappedStore(Func<TOutterKey, TInnerKey> innerMapping, Func<T, TInnerKey, TOutterKey> outterMapping, IStore<T, TInnerKey> store)
    {
        this.innerMapping = IsNotNull(innerMapping, message: MappedStoreInnerMappingRequired);
        this.outterMapping = IsNotNull(outterMapping, message: MappedStoreOutterMappingRequired);
        this.store = IsNotNull(store, message: MappedStoreStoreRequired);
    }

    public async Task<TOutterKey> CreateAsync(T item, CancellationToken? cancellationToken = default)
    {
        TInnerKey innerKey = await store
            .CreateAsync(item, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        return outterMapping(item, innerKey);
    }

    public Task DeleteAsync(T item, CancellationToken? cancellationToken = default)
    {
        return store.DeleteAsync(item, cancellationToken: cancellationToken);
    }

    public Task DeleteAsync(TOutterKey outterKey, CancellationToken? cancellationToken = default)
    {
        TInnerKey innerKey = innerMapping(outterKey);

        return store.DeleteAsync(innerKey, cancellationToken: cancellationToken);
    }

    public Task<T?> GetAsync(TOutterKey outterKey, CancellationToken? cancellationToken = default)
    {
        TInnerKey innerKey = innerMapping(outterKey);

        return store.GetAsync(innerKey, cancellationToken: cancellationToken);
    }

    public Task<PagedResult<T>> GetAsync(CancellationToken? cancellationToken = default, Paging? paging = default)
    {
        return store.GetAsync(cancellationToken: cancellationToken, paging: paging);
    }

    public Task UpdateAsync(T item, CancellationToken? cancellationToken = default)
    {
        return store.UpdateAsync(item, cancellationToken: cancellationToken);
    }
}