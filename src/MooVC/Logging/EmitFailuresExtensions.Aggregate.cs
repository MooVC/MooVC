namespace MooVC.Logging
{
    using System;
    using System.Collections.Generic;
    using static EmitWarningsExtensions;

    public static partial class EmitFailuresExtensions
    {
        public static void Aggregate<T>(this T source, Action<T> action, string? message = default)
            where T : IEmitFailures
        {
            new[] { source }.Aggregate(action, message: message);
        }

        public static void Aggregate<T>(this IEnumerable<T> sources, Action<T> action, string? message = default)
            where T : IEmitFailures
        {
            PerformAggregation(
                (source, handler) =>
                {
                    source.FailureEmitted += handler;

                    action(source);

                    source.FailureEmitted -= handler;
                },
                message,
                sources);
        }
    }
}