namespace MooVC.Persistence;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public abstract class SynchronousEventStore<T, TIndex>
    : IEventStore<T, TIndex>
    where T : class
{
    public virtual Task<T?> GetAsync(TIndex index, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformGet(index));
    }

    public virtual Task<TIndex> InsertAsync(T @event, CancellationToken? cancellationToken = default)
    {
        return Task.FromResult(PerformInsert(@event));
    }

    public virtual Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, CancellationToken? cancellationToken = default, ushort numberToRead = 10)
    {
        return Task.FromResult(PerformRead(lastIndex, numberToRead: numberToRead));
    }

    protected abstract TIndex PerformInsert(T @event);

    protected abstract T? PerformGet(TIndex index);

    protected abstract IEnumerable<T> PerformRead(TIndex lastIndex, ushort numberToRead = 10);
}