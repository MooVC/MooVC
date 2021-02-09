namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public abstract class Store<T, TKey>
        : IStore<T, TKey>
    {
        public abstract TKey Create(T item);

        public virtual async Task<TKey> CreateAsync(T item)
        {
            return await Task.FromResult(Create(item));
        }

        public abstract void Delete(T item);

        public abstract void Delete(TKey key);

        public virtual async Task DeleteAsync(T item)
        {
            Delete(item);

            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(TKey key)
        {
            Delete(key);

            await Task.CompletedTask;
        }

        public abstract T? Get(TKey key);

        public abstract IEnumerable<T> Get(Paging? paging = default);

        public virtual async Task<T?> GetAsync(TKey key)
        {
            return await Task.FromResult(Get(key));
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Paging? paging = default)
        {
            return await Task.FromResult(Get(paging: paging));
        }

        public abstract void Update(T item);

        public virtual async Task UpdateAsync(T item)
        {
            Update(item);

            await Task.CompletedTask;
        }
    }
}