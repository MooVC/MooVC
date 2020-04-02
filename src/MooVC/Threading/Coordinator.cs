namespace MooVC.Threading
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using static System.String;
    using static MooVC.Ensure;
    using static Resources;

    public sealed class Coordinator
    {
        private static readonly ConcurrentDictionary<string, object> contexts = new ConcurrentDictionary<string, object>();

        public static void Apply(string context, Action operation, TimeSpan? timeout = default)
        {
            ArgumentNotNullOrWhiteSpace(context, nameof(context), CoordinatorApplyContextRequired);
            ArgumentNotNull(operation, nameof(operation), CoordinatorApplyOperationRequired);

            timeout ??= Timeout.InfiniteTimeSpan;

            object monitor = contexts.GetOrAdd(context, _ => new object());

            if (Monitor.TryEnter(monitor, timeout.Value))
            {
                try
                {
                    operation();
                }
                finally
                {
                    Monitor.Exit(monitor);
                }
            }
            else
            {
                throw new TimeoutException(Format(CoordinatorApplyTimeout, context));
            }
        }
    }
}