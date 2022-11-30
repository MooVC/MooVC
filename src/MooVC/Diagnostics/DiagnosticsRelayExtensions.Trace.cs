namespace MooVC.Diagnostics;

using System;
using System.Threading;

public static partial class DiagnosticsRelayExtensions
{
    public static async void Trace(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        await diagnostics
            .TraceAsync(message, args)
            .ConfigureAwait(false);
    }

    public static async void Trace(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        await diagnostics
            .TraceAsync(cancellationToken, message, args)
            .ConfigureAwait(false);
    }

    public static async void Trace(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        await diagnostics
            .TraceAsync(cause, message, args)
            .ConfigureAwait(false);
    }

    public static async void Trace(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        await diagnostics
            .TraceAsync(cancellationToken, cause, message, args)
            .ConfigureAwait(false);
    }
}