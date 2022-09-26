namespace MooVC.Diagnostics;

using System;
using System.Threading;

public static partial class DiagnosticsRelayExtensions
{
    public static async void Critical(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .CriticalAsync(message, args)
            .ConfigureAwait(false);
    }

    public static async void Critical(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        string message,
        params object[] args)
    {
        await diagnostics
            .CriticalAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    public static async void Critical(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .CriticalAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    public static async void Critical(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        await diagnostics
            .CriticalAsync(cancellationToken, cause, message, args)
            .ConfigureAwait(false);
    }
}