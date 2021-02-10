namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class SynchronousEventStore<T, TIndex>
        : IEventStore<T, TIndex>
        where T : class
    {
        public virtual async Task<TIndex> InsertAsync(T @event)
        {
            return await Task.FromResult(PerformInsert(@event));
        }

        public virtual async Task<T?> ReadAsync(TIndex index)
        {
            return await Task.FromResult(PerformRead(index));
        }

        public virtual async Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, ushort numberToRead = 10)
        {
            return await Task.FromResult(PerformRead(lastIndex, numberToRead: numberToRead));
        }

        protected abstract TIndex PerformInsert(T @event);

        protected abstract T? PerformRead(TIndex index);

        protected abstract IEnumerable<T> PerformRead(TIndex lastIndex, ushort numberToRead = 10);
    }
}