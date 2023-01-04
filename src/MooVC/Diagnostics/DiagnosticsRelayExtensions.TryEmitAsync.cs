namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides extensions to support asynchronous emission of diagnostics events via an optional instance of <see cref="IDiagnosticsRelay"/>.
/// </summary>
public static partial class DiagnosticsRelayExtensions
{
    /// <summary>
    /// Asynchronously emits a diagnostic event if <paramref name="diagnostics"/> is not null, otherwise no action is taken.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <param name="cause">The <see cref="Exception" /> that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="impact">
    /// The perceived <see cref="Impact" /> of the event from the perspective of the source for which this relay is acting.
    /// </param>
    /// <param name="level">
    /// The perceived <see cref="Level" /> of the event from the perspective of the source for which this relay is acting.
    /// </param>
    /// <param name="message">An optional <see cref="DiagnosticsMessage" />, providing a friendly description of the event.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static Task TryEmitAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default)
    {
        if (diagnostics is { })
        {
            return diagnostics.EmitAsync(cancellationToken: cancellationToken, cause: cause, impact: impact, level: level, message: message);
        }

        return Task.CompletedTask;
    }
}