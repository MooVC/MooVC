namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using MooVC.Linq;

    public interface IStore<T, TKey>
    {
        TKey Create(T item);

        void Delete(T item);

        void Delete(TKey key);

        T? Get(TKey key);

        IEnumerable<T> Get(Paging? paging = default);

        void Update(T item);
    }
}