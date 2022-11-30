namespace MooVC.Diagnostics;

using System;
using System.Threading;

public static partial class DiagnosticsRelayExtensions
{
    public static async void Warning(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .WarningAsync(message, args)
            .ConfigureAwait(false);
    }

    public static async void Warning(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        await diagnostics
            .WarningAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    public static async void Warning(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .WarningAsync(cause, message, args)
            .ConfigureAwait(false);
    }

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