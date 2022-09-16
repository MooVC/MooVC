namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

public sealed class DiagnosticsEmitter<T>
    : IDiagnosticsEmitter
    where T : class, IEmitDiagnostics
{
    private readonly IDiagnosticsProxy diagnostics;
    private readonly T source;

    public DiagnosticsEmitter(T source, IDiagnosticsProxy? diagnostics = default)
    {
        this.source = ArgumentNotNull(source, nameof(source), DiagnosticsEmitterSourceRequired);
        this.diagnostics = diagnostics ?? new DiagnosticsProxy();
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted
    {
        add => diagnostics.DiagnosticsEmitted += value;
        remove => diagnostics.DiagnosticsEmitted -= value;
    }

    public Task EmitAsync(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        string? message = default)
    {
        return diagnostics.EmitAsync(source, cancellationToken: cancellationToken, cause: cause, impact: impact, level: level, message: message);
    }
}