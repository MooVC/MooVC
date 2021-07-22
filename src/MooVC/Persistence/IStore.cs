namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public interface IStore<T, TKey>
    {
        Task<TKey> CreateAsync(T item, CancellationToken? cancellationToken = default);

        Task DeleteAsync(T item, CancellationToken? cancellationToken = default);

        Task DeleteAsync(TKey key, CancellationToken? cancellationToken = default);

        Task<T?> GetAsync(TKey key, CancellationToken? cancellationToken = default);

        Task<IEnumerable<T>> GetAsync(
            CancellationToken? cancellationToken = default,
            Paging? paging = default);

        Task UpdateAsync(T item, CancellationToken? cancellationToken = default);
    }
}