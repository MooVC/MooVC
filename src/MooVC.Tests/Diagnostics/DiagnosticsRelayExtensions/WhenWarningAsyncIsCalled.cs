namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class WhenWarningAsyncIsCalled
    : FireAndAwait
{
    public WhenWarningAsyncIsCalled()
        : base(Level.Warning)
    {
    }

    protected override Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.WarningAsync(cancellationToken, cause, message);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.WarningAsync(cancellationToken, message);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.WarningAsync(cause, message);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.WarningAsync(message);
    }
}