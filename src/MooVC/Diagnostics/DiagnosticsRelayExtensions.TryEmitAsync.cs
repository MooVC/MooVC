namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public static partial class DiagnosticsRelayExtensions
{
    public static Task TryEmitAsync(
        this IDiagnosticsRelay? diagnostics,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        string? message = default)
    {
        if (diagnostics is { })
        {
            return diagnostics.EmitAsync(cancellationToken: cancellationToken, cause: cause, impact: impact, level: level, message: message);
        }

        return Task.CompletedTask;
    }
}