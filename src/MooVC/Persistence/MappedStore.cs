﻿namespace MooVC.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;
    using static MooVC.Ensure;
    using static Resources;

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

        public TOutterKey Create(T item)
        {
            TInnerKey innerKey = store.Create(item);

            return outterMapping(item, innerKey);
        }

        public async Task<TOutterKey> CreateAsync(T item)
        {
            TInnerKey innerKey = await store.CreateAsync(item);

            return outterMapping(item, innerKey);
        }

        public void Delete(T item)
        {
            store.Delete(item);
        }

        public void Delete(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            store.Delete(innerKey);
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

        public T? Get(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            return store.Get(innerKey);
        }

        public async Task<T?> GetAsync(TOutterKey outterKey)
        {
            TInnerKey innerKey = innerMapping(outterKey);

            return await store.GetAsync(innerKey);
        }

        public IEnumerable<T> Get(Paging? paging = default)
        {
            return store.Get(paging: paging);
        }

        public async Task<IEnumerable<T>> GetAsync(Paging? paging = default)
        {
            return await store.GetAsync(paging: paging);
        }

        public void Update(T item)
        {
            store.Update(item);
        }

        public async Task UpdateAsync(T item)
        {
            await store.UpdateAsync(item);
        }
    }
}