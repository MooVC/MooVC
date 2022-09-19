namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

public sealed class DiagnosticsRelay
    : IDiagnosticsRelay
{
    private readonly IDiagnosticsProxy diagnostics;
    private readonly IEmitDiagnostics source;
    private DiagnosticsEmittedAsyncEventHandler? @internal;
    private int listeners;

    public DiagnosticsRelay(IEmitDiagnostics source, IDiagnosticsProxy? diagnostics = default)
    {
        this.source = ArgumentNotNull(source, nameof(source), DiagnosticsEmitterSourceRequired);
        this.diagnostics = diagnostics ?? DiagnosticsProxy.Default;
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted
    {
        add
        {
            @internal += value;

            if (Interlocked.Increment(ref listeners) == 1)
            {
                diagnostics.DiagnosticsEmitted += DiagnosticsRelay_DiagnosticsEmitted;
            }
        }

        remove
        {
            if (Interlocked.Decrement(ref listeners) == 0)
            {
                diagnostics.DiagnosticsEmitted -= DiagnosticsRelay_DiagnosticsEmitted;
            }

            @internal -= value;
        }
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

    private Task DiagnosticsRelay_DiagnosticsEmitted(IEmitDiagnostics sender, DiagnosticsEmittedAsyncEventArgs e)
    {
        return @internal.PassiveInvokeAsync(sender, e);
    }
}