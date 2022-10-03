namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public static partial class DiagnosticsRelayExtensions
{
    public static Task WarningAsync(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        return diagnostics.WarningAsync(CancellationToken.None, message, args);
    }

    public static Task WarningAsync(this IDiagnosticsRelay? diagnostics, CancellationToken? cancellationToken, string message, params object[] args)
    {
        return diagnostics.WarningAsync(cancellationToken, default, message, args);
    }

    public static Task WarningAsync(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        return diagnostics.WarningAsync(CancellationToken.None, cause, message, args);
    }

    public static Task WarningAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        return diagnostics.TryEmitAsync(cancellationToken: cancellationToken, cause: cause, level: Level.Warning, message: (message, args));
    }
}