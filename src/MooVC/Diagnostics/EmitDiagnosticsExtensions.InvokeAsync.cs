namespace MooVC.Diagnostics;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MooVC.Collections.Generic;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

public static partial class EmitDiagnosticsExtensions
{
    public static async Task<IEnumerable<DiagnosticsEmittedAsyncEventArgs>> InvokeAsync<T>(
        this IEnumerable<T>? sources,
        Func<T, Task> action)
        where T : IEmitDiagnostics
    {
        if (sources is { })
        {
            _ = ArgumentNotNull(
                action,
                nameof(action),
                EmitDiagnosticsExtensionsInvokeActionRequired);

            async Task Action(T source, DiagnosticsEmittedAsyncEventHandler handler)
            {
                source.DiagnosticsEmitted += handler;

                await action(source)
                    .ConfigureAwait(false);

                source.DiagnosticsEmitted -= handler;
            }

            return await sources
                .PerformInvocationAsync(Action)
                .ConfigureAwait(false);
        }

        return Enumerable.Empty<DiagnosticsEmittedAsyncEventArgs>();
    }

    private static async Task<IEnumerable<DiagnosticsEmittedAsyncEventArgs>> PerformInvocationAsync<T>(
        this IEnumerable<T> sources,
        Func<T, DiagnosticsEmittedAsyncEventHandler, Task> action)
    {
        var diagnostics = new ConcurrentBag<DiagnosticsEmittedAsyncEventArgs>();

        Task Source_Raised(IEmitDiagnostics sender, DiagnosticsEmittedAsyncEventArgs e)
        {
            diagnostics.Add(e);

            return Task.CompletedTask;
        }

        await sources
            .ForAllAsync(source => action(source, Source_Raised))
            .ConfigureAwait(false);

        return diagnostics;
    }
}