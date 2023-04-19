namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Represents a proxy for emitting diagnostics messages.
/// </summary>
public interface IDiagnosticsProxy
    : IEmitDiagnostics
{
    /// <summary>
    /// Gets the diagnostic level assigned by the proxy based on the perceived impact.
    /// </summary>
    /// <param name="impact">The perceived <see cref="Impact" /> of the event.</param>
    /// <returns>The diagnostic level assigned by the proxy based on the perceived impact.</returns>
    Level this[Impact impact] { get; }

    /// <summary>
    /// Emits a diagnostic event asynchronously if the proxy deems it appropriate.
    /// </summary>
    /// <param name="source">The object emitting the event for the purpose of diagnostics.</param>
    /// <param name="cause">The <see cref="Exception" /> that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="impact">The perceived <see cref="Impact" /> of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="level">The perceived <see cref="Level" /> of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="message">A <see cref="DiagnosticsMessage" />, providing a friendly description of the event, if any.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result of the task is an object containing information about the emitted diagnostic message, or null if the message was not emitted.
    /// </returns>
    Task<DiagnosticsEmittedAsyncEventArgs?> TryEmitAsync(
        IEmitDiagnostics source,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default,
        CancellationToken cancellationToken = default);
}