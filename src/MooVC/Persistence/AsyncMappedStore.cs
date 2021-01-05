namespace MooVC.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;
    using static MooVC.Ensure;
    using static Resources;

    public sealed class AsyncMappedStore<T, TOutterKey, TInnerKey>
        : IAsyncStore<T, TOutterKey>
    {
        private readonly Func<TOutterKey, TInnerKey> innerMapping;
        private readonly Func<T, TInnerKey, TOutterKey> outterMapping;
        private readonly IAsyncStore<T, TInnerKey> store;

        public AsyncMappedStore(
            Func<TOutterKey, TInnerKey> innerMapping,
            Func<T, TInnerKey, TOutterKey> outterMapping,
            IAsyncStore<T, TInnerKey> store)
        {
            ArgumentNotNull(innerMapping, nameof(innerMapping), AsyncMappedStoreInnerMappingRequired);
            ArgumentNotNull(outterMapping, nameof(outterMapping), AsyncMappedStoreOutterMappingRequired);
            ArgumentNotNull(store, nameof(store), AsyncMappedStoreStoreRequired);

            this.innerMapping = innerMapping;
            this.outterMapping = outterMapping;
            this.store = store;
        }

        public async Task<TOutterKey> CreateAsync(T item)
        {
            TInnerKey innerKey = await store.CreateAsync(item);

            return outterMapping(item, innerKey);
        }

        public async Task DeleteAsync(T item)
        {
            await store.DeleteAsync(item);
        }

        public async Task DeleteAsync(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            await store.DeleteAsync(innerKey);
        }

        public async Task<T> GetAsync(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            return await store.GetAsync(innerKey);
        }

        public async Task<IEnumerable<T>> GetAsync(Paging? paging = default)
        {
            return await store.GetAsync(paging: paging);
        }

        public async Task UpdateAsync(T item)
        {
            await store.UpdateAsync(item);
        }
    }
}