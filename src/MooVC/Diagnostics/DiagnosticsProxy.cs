namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class DiagnosticsProxy
    : IDiagnosticsProxy
{
    private readonly Level level;

    public DiagnosticsProxy(Level @default = Level.Error)
    {
        level = @default;
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    public Task EmitAsync<T>(
        T source,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Level? level = default,
        string? message = default)
        where T : class, IEmitDiagnostics
    {
        level ??= this.level;

        return DiagnosticsEmitted.PassiveInvokeAsync(
            source,
            new DiagnosticsEmittedAsyncEventArgs(cancellationToken: cancellationToken, cause: cause, level: level.Value, message: message));
    }
}