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
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        diagnostics.Error(cause, message, cancellationToken, args);
    }

    protected override void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        diagnostics.Error(message, cancellationToken, args);
    }

    protected override void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        diagnostics.Error(cause, message, args);
    }

    protected override void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        diagnostics.Error(message, args);
    }
}