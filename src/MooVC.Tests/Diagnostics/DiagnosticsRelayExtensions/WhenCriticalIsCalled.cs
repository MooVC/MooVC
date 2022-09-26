namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;

public sealed class WhenCriticalIsCalled
    : FireAndForget
{
    public WhenCriticalIsCalled()
        : base(Level.Critical)
    {
    }

    protected override void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Critical(cancellationToken, cause, message);
    }

    protected override void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Critical(cancellationToken, message);
    }

    protected override void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Critical(cause, message);
    }

    protected override void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Critical(message);
    }
}