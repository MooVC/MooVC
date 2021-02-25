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

            Task InvokeOperation()
            {
                operation();

                return Task.CompletedTask;
            }

            CoordinateAsync(context, InvokeOperation, timeout)
                .GetAwaiter()
                .GetResult();
        }

        public static Task ApplyAsync(string context, Func<Task> operation, TimeSpan? timeout = default)
        {
            ArgumentNotNull(operation, nameof(operation), CoordinatorApplyOperationRequired);

            return CoordinateAsync(context, operation, timeout);
        }

        private static async Task CoordinateAsync(string context, Func<Task> operation, TimeSpan? timeout)
        {
            ArgumentNotNullOrWhiteSpace(context, nameof(context), CoordinatorApplyContextRequired);

            timeout ??= Timeout.InfiniteTimeSpan;

            object monitor = contexts.GetOrAdd(context, _ => new object());

            if (Monitor.TryEnter(monitor, timeout.Value))
            {
                try
                {
                    await operation();
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