namespace MooVC.Diagnostics;

using System;
using System.Threading;

public static partial class DiagnosticsRelayExtensions
{
    public static async void Information(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .InformationAsync(message, args)
            .ConfigureAwait(false);
    }

    public static async void Information(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        string message,
        params object[] args)
    {
        await diagnostics
            .InformationAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    public static async void Information(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .InformationAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    public static async void Information(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        await diagnostics
            .InformationAsync(cancellationToken, cause, message, args)
            .ConfigureAwait(false);
    }
}