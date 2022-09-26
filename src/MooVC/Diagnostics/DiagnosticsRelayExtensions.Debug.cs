namespace MooVC.Diagnostics;

using System;
using System.Threading;

public static partial class DiagnosticsRelayExtensions
{
    public static async void Debug(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .DebugAsync(message, args)
            .ConfigureAwait(false);
    }

    public static async void Debug(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        await diagnostics
            .DebugAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    public static async void Debug(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .DebugAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    public static async void Debug(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        await diagnostics
            .DebugAsync(cancellationToken, cause, message, args)
            .ConfigureAwait(false);
    }
}