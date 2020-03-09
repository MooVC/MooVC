namespace MooVC.Persistence
{
    using System.Collections.Generic;
    using MooVC.Linq;

    public interface IEventStore<T, TIndex>
        where T : class
    {
        TIndex Insert(T @event);

        T Read(TIndex id);

        IEnumerable<T> Read(TIndex lastIndex, ushort numberToRead = Paging.DefaultSize);
    }
}