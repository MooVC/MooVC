namespace MooVC.Diagnostics
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Collections.Generic;
    using static MooVC.Diagnostics.Resources;
    using static MooVC.Ensure;

    public static partial class EmitDiagnosticsExtensions
    {
        public static IEnumerable<DiagnosticsEmittedEventArgs> Invoke<T>(this IEnumerable<T>? sources, Action<T> action)
            where T : IEmitDiagnostics
        {
            if (sources is { })
            {
                ArgumentNotNull(action, nameof(action), EmitDiagnosticsExtensionsInvokeActionRequired);

                return sources.PerformInvocation(
                    (source, handler) =>
                    {
                        source.DiagnosticsEmitted += handler;

                        action(source);

                        source.DiagnosticsEmitted -= handler;
                    });
            }

            return Enumerable.Empty<DiagnosticsEmittedEventArgs>();
        }

        private static IEnumerable<DiagnosticsEmittedEventArgs> PerformInvocation<T>(
            this IEnumerable<T> sources,
            Action<T, DiagnosticsEmittedEventHandler> action)
        {
            var diagnostics = new ConcurrentBag<DiagnosticsEmittedEventArgs>();

            void Source_Raised(IEmitDiagnostics sender, DiagnosticsEmittedEventArgs e)
            {
                diagnostics.Add(e);
            }

            sources.ForAll(source => action(source, Source_Raised));

            return diagnostics;
        }
    }
}