namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public interface IEventStore<T, TIndex>
        where T : class
    {
        TIndex Insert(T @event);

        Task<TIndex> InsertAsync(T @event);

        T? Read(TIndex index);

        Task<T?> ReadAsync(TIndex index);

        IEnumerable<T> Read(TIndex lastIndex, ushort numberToRead = Paging.DefaultSize);

        Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, ushort numberToRead = Paging.DefaultSize);
    }
}