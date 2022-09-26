namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;
using static System.String;

public static partial class DiagnosticsRelayExtensions
{
    public static Task DebugAsync(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        return diagnostics.DebugAsync(CancellationToken.None, message, args);
    }

    public static Task DebugAsync(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        return diagnostics.DebugAsync(cancellationToken, default, message, args);
    }

    public static Task DebugAsync(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        return diagnostics.DebugAsync(CancellationToken.None, cause, message, args);
    }

    public static Task DebugAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        return diagnostics.TryEmitAsync(cancellationToken: cancellationToken, cause: cause, level: Level.Debug, message: Format(message, args));
    }
}