namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public static partial class DiagnosticsRelayExtensions
{
    public static Task InformationAsync(this IDiagnosticsRelay? diagnostics, string message, params object[] args)
    {
        return diagnostics.InformationAsync(CancellationToken.None, message, args);
    }

    public static Task InformationAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        string message,
        params object[] args)
    {
        return diagnostics.InformationAsync(cancellationToken, default, message, args);
    }

    public static Task InformationAsync(this IDiagnosticsRelay? diagnostics, Exception? cause, string message, params object[] args)
    {
        return diagnostics.InformationAsync(CancellationToken.None, cause, message, args);
    }

    public static Task InformationAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken,
        Exception? cause,
        string message,
        params object[] args)
    {
        return diagnostics.TryEmitAsync(
            cancellationToken: cancellationToken,
            cause: cause,
            level: Level.Information,
            message: (message, args));
    }
}