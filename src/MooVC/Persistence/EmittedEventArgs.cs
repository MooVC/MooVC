namespace MooVC.Persistence
{
    using System;

    public class EmittedEventArgs<T> 
        : EventArgs
        where T : class
    {
        public EmittedEventArgs(T @event)
        {
            Ensure.ArgumentNotNull(@event, nameof(@event));

            Event = @event;
        }

        public T Event { get; }
    }
}