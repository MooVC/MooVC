namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public interface IStore<T, TKey>
    {
        TKey Create(T item);

        Task<TKey> CreateAsync(T item);

        void Delete(T item);

        void Delete(TKey key);

        Task DeleteAsync(T item);

        Task DeleteAsync(TKey key);

        T? Get(TKey key);

        Task<T?> GetAsync(TKey key);

        IEnumerable<T> Get(Paging? paging = default);

        Task<IEnumerable<T>> GetAsync(Paging? paging = default);

        void Update(T item);

        Task UpdateAsync(T item);
    }
}