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

    public DiagnosticsRelay(IEmitDiagnostics source, IDiagnosticsProxy? diagnostics = default)
    {
        this.source = IsNotNull(source, message: DiagnosticsEmitterSourceRequired);
        this.diagnostics = diagnostics ?? DiagnosticsProxy.Default;
    }

    public event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    public async Task EmitAsync(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default)
    {
        DiagnosticsEmittedAsyncEventArgs? @event = await diagnostics
            .TryEmitAsync(this, cancellationToken: cancellationToken, cause: cause, impact: impact, level: level, message: message)
            .ConfigureAwait(false);

        if (@event is { })
        {
            await DiagnosticsEmitted
                .PassiveInvokeAsync(source, @event)
                .ConfigureAwait(false);
        }
    }
}