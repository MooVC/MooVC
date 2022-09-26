namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;

public sealed class WhenErrorIsCalled
    : FireAndForget
{
    public WhenErrorIsCalled()
        : base(Level.Error)
    {
    }

    protected override void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Error(cancellationToken, cause, message);
    }

    protected override void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Error(cancellationToken, message);
    }

    protected override void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Error(cause, message);
    }

    protected override void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Error(message);
    }
}