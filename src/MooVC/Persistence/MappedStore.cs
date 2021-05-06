namespace MooVC.Persistence
{
    using System;
    using System.Collections.Generic;
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

        public MappedStore(
            Func<TOutterKey, TInnerKey> innerMapping,
            Func<T, TInnerKey, TOutterKey> outterMapping,
            IStore<T, TInnerKey> store)
        {
            ArgumentNotNull(innerMapping, nameof(innerMapping), MappedStoreInnerMappingRequired);
            ArgumentNotNull(outterMapping, nameof(outterMapping), MappedStoreOutterMappingRequired);
            ArgumentNotNull(store, nameof(store), MappedStoreStoreRequired);

            this.innerMapping = innerMapping;
            this.outterMapping = outterMapping;
            this.store = store;
        }

        public async Task<TOutterKey> CreateAsync(T item)
        {
            TInnerKey innerKey = await store.CreateAsync(item);

            return outterMapping(item, innerKey);
        }

        public Task DeleteAsync(T item)
        {
            return store.DeleteAsync(item);
        }

        public Task DeleteAsync(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            return store.DeleteAsync(innerKey);
        }

        public Task<T?> GetAsync(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            return store.GetAsync(innerKey);
        }

        public Task<IEnumerable<T>> GetAsync(Paging? paging = default)
        {
            return store.GetAsync(paging: paging);
        }

        public Task UpdateAsync(T item)
        {
            return store.UpdateAsync(item);
        }
    }
}