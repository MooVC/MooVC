namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

/// <summary>
/// Represents an object that can receive and relay diagnostic events on behalf of another object.
/// </summary>
public sealed class DiagnosticsRelay
    : IDiagnosticsRelay
{
    private readonly IDiagnosticsProxy diagnostics;
    private readonly IEmitDiagnostics source;

    /// <summary>
    /// Initializes a new instance of the <see cref="DiagnosticsRelay"/> class.
    /// </summary>
    /// <param name="source">The source that will be associated with the events emitted by the relay.</param>
    /// <param name="diagnostics">
    /// The proxy that determines if diagnostics are to be emitted, with the default configuration used if not provided.
    /// </param>
    /// <exception cref="ArgumentNullException">The <paramref name="source"/> is <see langword="null" />.</exception>
    public DiagnosticsRelay(IEmitDiagnostics source, IDiagnosticsProxy? diagnostics = default)
    {
        this.source = IsNotNull(source, argumentName: nameof(source), message: DiagnosticsEmitterSourceRequired);
        this.diagnostics = diagnostics ?? DiagnosticsProxy.Default;
    }

    /// <summary>
    /// An event that is raised when a relevant diagnostic related occurance is encountered.
    /// </summary>
    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    /// <summary>
    /// Emits a diagnostic event asynchronously if the event is deemed relevant by the configuration associated with the proxy.
    /// </summary>
    /// <param name="cause">The <see cref="Exception" /> that caused the diagnostic event to be emitted, if any.</param>
    /// <param name="impact">
    /// The perceived <see cref="Impact" /> of the event from the perspective of the source for which this relay is acting.
    /// </param>
    /// <param name="level">
    /// The perceived <see cref="Level" /> of the event from the perspective of the source for which this relay is acting.
    /// </param>
    /// <param name="message">An optional <see cref="DiagnosticsMessage" />, providing a friendly description of the event.</param>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task EmitAsync(
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default,
        CancellationToken cancellationToken = default)
    {
        DiagnosticsEmittedAsyncEventArgs? @event = await diagnostics
            .TryEmitAsync(this, cause: cause, impact: impact, level: level, message: message, cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        if (@event is not null)
        {
            await DiagnosticsEmitted
                .PassiveInvokeAsync(source, @event)
                .ConfigureAwait(false);
        }
    }
}