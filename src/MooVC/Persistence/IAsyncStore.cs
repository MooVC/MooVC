namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public interface IAsyncStore<T, TKey>
    {
        Task<TKey> CreateAsync(T item);

        Task DeleteAsync(T item);

        Task DeleteAsync(TKey key);

        Task<T> GetAsync(TKey key);

        Task<IEnumerable<T>> GetAsync(Paging? paging = default);

        Task UpdateAsync(T item);
    }
}