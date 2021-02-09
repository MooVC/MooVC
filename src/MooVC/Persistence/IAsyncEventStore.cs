namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MooVC.Linq;

    public interface IAsyncEventStore<T, TIndex>
        where T : class
    {
        Task<TIndex> InsertAsync(T @event);

        Task<T?> ReadAsync(TIndex id);

        IAsyncEnumerable<T> ReadAsync(TIndex lastIndex, ushort numberToRead = Paging.DefaultSize);
    }
}