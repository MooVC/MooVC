namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public static partial class DiagnosticsRelayExtensions
{
    public static Task TraceAsync(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        return diagnostics.TraceAsync(CancellationToken.None, message, args);
    }

    public static Task TraceAsync(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        return diagnostics.TraceAsync(cancellationToken, default, message, args);
    }

    public static Task TraceAsync(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        return diagnostics.TraceAsync(CancellationToken.None, cause, message, args);
    }

    public static Task TraceAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        return diagnostics.TryEmitAsync(cancellationToken: cancellationToken, cause: cause, level: Level.Trace, message: (message, args));
    }
}