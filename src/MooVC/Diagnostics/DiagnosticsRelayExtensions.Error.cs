namespace MooVC.Diagnostics;

using System;
using System.Threading;

public static partial class DiagnosticsRelayExtensions
{
    public static async void Error(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .ErrorAsync(message, args)
            .ConfigureAwait(false);
    }

    public static async void Error(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        await diagnostics
            .ErrorAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    public static async void Error(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .ErrorAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    public static async void Error(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        await diagnostics
            .ErrorAsync(cancellationToken, cause, message, args)
            .ConfigureAwait(false);
    }
}