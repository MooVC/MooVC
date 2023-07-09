namespace MooVC.Diagnostics;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MooVC.Collections.Generic;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions to support capture of diagnostics events from source of type <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration that implement <see cref="IEmitDiagnostics"/>.</typeparam>
public static partial class EmitDiagnosticsExtensions
{
    /// <summary>
    /// Invokes the specified asynchronous action on each element of a sequence of sources, and returns the emitted diagnostics.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the input sequence.</typeparam>
    /// <param name="sources">The input sequence.</param>
    /// <param name="action">An asynchronous action to be performed on each element of the input sequence.</param>
    /// <exception cref="ArgumentNullException">Thrown if the action is <see langword="null" />.</exception>
    /// <returns>A collection containing the emitted diagnostics.</returns>
    public static async Task<IEnumerable<DiagnosticsEmittedAsyncEventArgs>> InvokeAsync<T>(this IEnumerable<T>? sources, Func<T, Task> action)
        where T : IEmitDiagnostics
    {
        if (sources is null)
        {
            return Enumerable.Empty<DiagnosticsEmittedAsyncEventArgs>();
        }

        _ = IsNotNull(action, argumentName: nameof(action), message: EmitDiagnosticsExtensionsInvokeActionRequired);

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