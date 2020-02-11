namespace ControlSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Logging;

    public static partial class EmitWarningsExtensions
    {
        public static void Aggregate<T>(this T source, Action<T> action, string? message = default)
            where T : IEmitWarnings
        {
            new[] { source }.Aggregate(action, message: message);
        }

        public static void Aggregate<T>(this IEnumerable<T> sources, Action<T> action, string? message = default)
            where T : IEmitWarnings
        {
            PerformAggregation(
                (source, handler) =>
                {
                    source.WarningEmitted += handler;

                    action(source);

                    source.WarningEmitted -= handler;
                },
                message,
                sources);
        }

        internal static void PerformAggregation<T>(Action<T, PassiveExceptionEventHandler> action, string? message, IEnumerable<T> sources)
        {
            var exceptions = new List<Exception>();

            void Source_Raised(object sender, PassiveExceptionEventArgs e)
            {
                if (e.Exception is { })
                {
                    exceptions.Add(e.Exception);
                }
            }

            foreach (T source in sources)
            {
                action(source, Source_Raised);
            }

            if (exceptions.Any())
            {
                if (string.IsNullOrEmpty(message))
                {
                    throw new AggregateException(exceptions);
                }

                throw new AggregateException(message, exceptions);
            }
        }
    }
}