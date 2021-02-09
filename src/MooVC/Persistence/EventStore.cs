namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class EventStore<T, TIndex>
        : IEventStore<T, TIndex>
        where T : class
    {
        public abstract TIndex Insert(T @event);

        public virtual async Task<TIndex> InsertAsync(T @event)
        {
            return await Task.FromResult(Insert(@event));
        }

        public abstract T? Read(TIndex index);

        public abstract IEnumerable<T> Read(TIndex lastIndex, ushort numberToRead = 10);

        public virtual async Task<T?> ReadAsync(TIndex index)
        {
            return await Task.FromResult(Read(index));
        }

        public virtual async Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, ushort numberToRead = 10)
        {
            return await Task.FromResult(Read(lastIndex, numberToRead: numberToRead));
        }
    }
}