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
    /// <param name="impact">The perceived impact of the event.</param>
    /// <returns>The diagnostic level assigned by the proxy based on the perceived impact.</returns>
    Level this[Impact impact] { get; }

    /// <summary>
    /// Emits a diagnostic event asynchronously if the proxy deems it appropriate.
    /// </summary>
    /// <param name="source">The object emitting the event for the purpose of diagnostics.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <param name="cause">The exception that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="impact">The perceived impact of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="level">The perceived level of the event from the perspective of the <paramref name="source"/>.</param>
    /// <param name="message">A friendly description of the event, if any.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the task is an object containing
    /// information about the emitted diagnostic message, or null if the message was not emitted.</returns>
    Task<DiagnosticsEmittedAsyncEventArgs?> TryEmitAsync(
        IEmitDiagnostics source,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default);
}