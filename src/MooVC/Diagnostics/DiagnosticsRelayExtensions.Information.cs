namespace MooVC.Diagnostics;

using System;
using System.Threading;

/// <summary>
/// Provides extensions to support emission of information diagnostics events via an instance of <see cref="IDiagnosticsRelay"/>.
/// </summary>
public static partial class DiagnosticsRelayExtensions
{
    /// <summary>
    /// Emits an information diagnostic event with the specified message.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Information(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .InformationAsync(message, args)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Emits an information diagnostic event with the specified message and cancellation token.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the emission operation.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Information(
        this IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken cancellationToken,
        params object[] args)
    {
        await diagnostics
            .InformationAsync(message, cancellationToken, args)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Emits an information diagnostic event with the specified message and cause.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cause">The cause of the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Information(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .InformationAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Emits an information diagnostic event with the specified message, cause, and cancellation token.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cause">The cause of the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the emission operation.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Information(
        this IDiagnosticsRelay? diagnostics,
        Exception? cause,
        string message,
        CancellationToken cancellationToken,
        params object[] args)
    {
        await diagnostics
            .InformationAsync(cause, message, cancellationToken, args)
            .ConfigureAwait(false);
    }
}