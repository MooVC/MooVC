namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public abstract class SynchronousStore<T, TKey>
        : IStore<T, TKey>
    {
        public virtual async Task<TKey> CreateAsync(T item)
        {
            return await Task.FromResult(PerformCreate(item));
        }

        public virtual async Task DeleteAsync(T item)
        {
            PerformDelete(item);

            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(TKey key)
        {
            PerformDelete(key);

            await Task.CompletedTask;
        }

        public virtual async Task<T?> GetAsync(TKey key)
        {
            return await Task.FromResult(PerformGet(key));
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Paging? paging = default)
        {
            return await Task.FromResult(PerformGet(paging: paging));
        }

        public virtual async Task UpdateAsync(T item)
        {
            PerformUpdate(item);

            await Task.CompletedTask;
        }

        protected abstract TKey PerformCreate(T item);

        protected abstract void PerformDelete(T item);

        protected abstract void PerformDelete(TKey key);

        protected abstract T? PerformGet(TKey key);

        protected abstract IEnumerable<T> PerformGet(Paging? paging = default);

        protected abstract void PerformUpdate(T item);
    }
}