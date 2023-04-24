namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides extensions to support asynchronous emission of information diagnostics events via an instance of <see cref="IDiagnosticsRelay"/>.
/// </summary>
public static partial class DiagnosticsRelayExtensions
{
    /// <summary>
    /// Asynchronously emits an information diagnostic event with the specified message.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static Task InformationAsync(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        return diagnostics.InformationAsync(message, default, args);
    }

    /// <summary>
    /// Asynchronously emits an information diagnostic event with the specified message and cancellation token.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the emission operation.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static Task InformationAsync(
        this IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken cancellationToken,
        params object[] args)
    {
        return diagnostics.InformationAsync(default, message, cancellationToken, args);
    }

    /// <summary>
    /// Asynchronously emits an information diagnostic event with the specified message and cause.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cause">The cause of the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static Task InformationAsync(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        return diagnostics.InformationAsync(cause, message, default, args);
    }

    /// <summary>
    /// Asynchronously emits an information diagnostic event with the specified message, cause, and cancellation token.
    /// </summary>
    /// <param name="diagnostics">The <see cref="IDiagnosticsRelay"/> to use to emit the diagnostic event.</param>
    /// <param name="cause">The cause of the diagnostic event.</param>
    /// <param name="message">The message associated with the diagnostic event.</param>
    /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> that can be used to cancel the emission operation.</param>
    /// <param name="args">The arguments of the message (if any).</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static Task InformationAsync(
        this IDiagnosticsRelay? diagnostics,
        Exception? cause,
        string message,
        CancellationToken cancellationToken,
        params object[] args)
    {
        return diagnostics.TryEmitAsync(cause: cause, level: Level.Information, message: (message, args), cancellationToken: cancellationToken);
    }
}