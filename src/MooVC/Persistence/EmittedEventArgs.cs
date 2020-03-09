namespace MooVC.Persistence
{
    using System;
    using static MooVC.Ensure;
    using static Resources;

    public class EmittedEventArgs<T>
        : EventArgs
        where T : class
    {
        public EmittedEventArgs(T @event)
        {
            ArgumentNotNull(@event, nameof(@event), EmittedEventArgsEventRequired);

            Event = @event;
        }

        public T Event { get; }
    }
}