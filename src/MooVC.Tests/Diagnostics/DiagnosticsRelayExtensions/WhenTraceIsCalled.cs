namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;

public sealed class WhenTraceIsCalled
    : FireAndForget
{
    public WhenTraceIsCalled()
        : base(Level.Trace)
    {
    }

    protected override void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Trace(cancellationToken, cause, message);
    }

    protected override void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Trace(cancellationToken, message);
    }

    protected override void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Trace(cause, message);
    }

    protected override void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Trace(message);
    }
}