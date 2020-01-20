namespace MooVC.Persistence
{
    public interface IEventStore<T, TId>
        where T : class
    {
        void Insert(T @event);

        T Read(TId id);
    }
}