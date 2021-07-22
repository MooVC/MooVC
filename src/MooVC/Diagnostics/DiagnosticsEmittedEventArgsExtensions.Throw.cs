namespace MooVC.Diagnostics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static MooVC.Diagnostics.Resources;
    using static MooVC.Ensure;

    public static class DiagnosticsEmittedEventArgsExtensions
    {
        public static void Throw(
            this IEnumerable<DiagnosticsEmittedAsyncEventArgs>? diagnostics,
            Level level = Level.Warning,
            string? message = default)
        {
            diagnostics.Throw((diagnostic, _) => diagnostic.Level >= level, message: message);
        }

        public static void Throw(
            this IEnumerable<DiagnosticsEmittedAsyncEventArgs>? diagnostics,
            Func<DiagnosticsEmittedAsyncEventArgs, Exception, bool> predicate,
            string? message = default)
        {
            if (diagnostics is { })
            {
                ArgumentNotNull(predicate, nameof(predicate), DiagnosticsEmittedEventArgsExtensionsThrowPredicateRequired);

                IEnumerable<Exception> matches = diagnostics
                    .Where(diagnostic => diagnostic.Cause is { })
                    .Where(diagnostic => predicate(diagnostic, diagnostic.Cause!))
                    .Select(diagnostic => diagnostic.Cause!)
                    .ToArray();

                if (matches.Any())
                {
                    throw new AggregateException(message, matches.ToArray());
                }
            }
        }
    }
}