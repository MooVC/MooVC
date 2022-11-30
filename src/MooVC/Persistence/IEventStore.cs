namespace MooVC.Persistence;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MooVC.Linq;

public interface IEventStore<T, TIndex>
    where T : class
{
    Task<T?> GetAsync(TIndex index, CancellationToken? cancellationToken = default);

    Task<TIndex> InsertAsync(T @event, CancellationToken? cancellationToken = default);

    Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, CancellationToken? cancellationToken = default, ushort numberToRead = Paging.DefaultSize);
}