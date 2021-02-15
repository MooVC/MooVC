namespace MooVC.Threading
{
    using System;
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using static System.String;
    using static MooVC.Ensure;
    using static MooVC.Threading.Resources;

    public sealed class Coordinator
    {
        private static readonly ConcurrentDictionary<string, object> contexts = new ConcurrentDictionary<string, object>();

        public static void Apply(string context, Action operation, TimeSpan? timeout = default)
        {
            ArgumentNotNull(operation, nameof(operation), CoordinatorApplyOperationRequired);

            object? InvokeOperation()
            {
                operation();

                return default;
            }

            _ = Coordinate(context, InvokeOperation, timeout);
        }

        public static Task ApplyAsync(string context, Func<Task> operation, TimeSpan? timeout = default)
        {
            ArgumentNotNull(operation, nameof(operation), CoordinatorApplyOperationRequired);

            return Coordinate(context, operation, timeout);
        }

        private static T Coordinate<T>(string context, Func<T> operation, TimeSpan? timeout)
        {
            ArgumentNotNullOrWhiteSpace(context, nameof(context), CoordinatorApplyContextRequired);

            timeout ??= Timeout.InfiniteTimeSpan;

            object monitor = contexts.GetOrAdd(context, _ => new object());

            if (Monitor.TryEnter(monitor, timeout.Value))
            {
                try
                {
                    return operation();
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