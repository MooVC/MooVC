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
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <param name="cause">The exception that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="impact">The perceived impact of the event from the perspective of the source for which this relay is acting.</param>
    /// <param name="level">The perceived level of the event from the perspective of the source for which this relay is acting.</param>
    /// <param name="message">A friendly description of the event, if any.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    Task EmitAsync(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default);
}