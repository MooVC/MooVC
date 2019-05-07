namespace MooVC.Persistence
{
    public interface IStore<T, TKey>
    {
        TKey Create(T item);

        void Delete(T item);

        void Delete(TKey key);

        T Get(TKey key);

        void Update(T item);
    }
}