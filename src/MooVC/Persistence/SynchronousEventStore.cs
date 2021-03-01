namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class SynchronousEventStore<T, TIndex>
        : IEventStore<T, TIndex>
        where T : class
    {
        public virtual Task<TIndex> InsertAsync(T @event)
        {
            return Task.FromResult(PerformInsert(@event));
        }

        public virtual Task<T?> ReadAsync(TIndex index)
        {
            return Task.FromResult(PerformRead(index));
        }

        public virtual Task<IEnumerable<T>> ReadAsync(TIndex lastIndex, ushort numberToRead = 10)
        {
            return Task.FromResult(PerformRead(lastIndex, numberToRead: numberToRead));
        }

        protected abstract TIndex PerformInsert(T @event);

        protected abstract T? PerformRead(TIndex index);

        protected abstract IEnumerable<T> PerformRead(TIndex lastIndex, ushort numberToRead = 10);
    }
}