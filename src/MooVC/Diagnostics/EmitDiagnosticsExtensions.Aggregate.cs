namespace MooVC.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static System.String;

    public static partial class EmitDiagnosticsExtensions
    {
        public static void Aggregate<T>(this T source, Action<T> action, string? message = default)
            where T : IEmitDiagnostics
        {
            new[] { source }.Aggregate(action, message: message);
        }

        public static void Aggregate<T>(this IEnumerable<T> sources, Action<T> action, string? message = default)
            where T : IEmitDiagnostics
        {
            PerformAggregation(
                (source, handler) =>
                {
                    source.DiagnosticsEmitted += handler;

                    action(source);

                    source.DiagnosticsEmitted -= handler;
                },
                message,
                sources);
        }

        internal static void PerformAggregation<T>(
            Action<T, DiagnosticsEmittedEventHandler> action,
            string? message,
            IEnumerable<T> sources)
        {
            var causes = new List<Exception>();

            void Source_Raised(IEmitDiagnostics sender, DiagnosticsEmittedEventArgs e)
            {
                if (e.Cause is { })
                {
                    causes.Add(e.Cause);
                }
            }

            foreach (T source in sources)
            {
                action(source, Source_Raised);
            }

            if (causes.Any())
            {
                if (IsNullOrEmpty(message))
                {
                    throw new AggregateException(causes);
                }

                throw new AggregateException(message, causes);
            }
        }
    }
}