namespace MooVC.Persistence
{
    using System;
    using MooVC.Logging;

    public interface IEventStore<T, TId>
        : IEmitFailures
        where T : class
    {
        event EventHandler<EmittedEventArgs<T>> Emitted;

        void Insert(T @event);

        T Read(TId id);
    }
}