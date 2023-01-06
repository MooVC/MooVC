namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Represents an object that can receive and relay diagnostic events on behalf of another object.
/// </summary>
public interface IDiagnosticsRelay
    : IEmitDiagnostics
{
    /// <summary>
    /// Emits a diagnostic event asynchronously.
    /// </summary>
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
    Task EmitAsync(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default);
}