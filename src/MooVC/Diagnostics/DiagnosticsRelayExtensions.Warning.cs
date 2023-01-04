namespace MooVC.Diagnostics;

using System;
using System.Threading;

/// <summary>
/// Provides extensions to support emission of warning diagnostics events via an instance of <see cref="IDiagnosticsRelay"/>.
/// </summary>
public static partial class DiagnosticsRelayExtensions
{
    /// <summary>
    /// Emits a warning diagnostic event with the specified message.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Warning(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .WarningAsync(message, args)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Emits a warning diagnostic event with the specified message and cancellation token.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the emission operation.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Warning(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        await diagnostics
            .WarningAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Emits a warning diagnostic event with the specified message and cause.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cause">The cause of the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Warning(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .WarningAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Emits a warning diagnostic event with the specified message, cause, and cancellation token.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the emission operation.</param>
    /// <param name="cause">The cause of the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    public static async void Warning(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        await diagnostics
            .WarningAsync(cancellationToken, cause, message, args)
            .ConfigureAwait(false);
    }
}