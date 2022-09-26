namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;

public sealed class WhenInformationIsCalled
    : FireAndForget
{
    public WhenInformationIsCalled()
        : base(Level.Information)
    {
    }

    protected override void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Information(cancellationToken, cause, message);
    }

    protected override void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Information(cancellationToken, message);
    }

    protected override void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Information(cause, message);
    }

    protected override void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        diagnostics.Information(message);
    }
}