namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class WhenCriticalAsyncIsCalled
    : FireAndAwait
{
    public WhenCriticalAsyncIsCalled()
        : base(Level.Critical)
    {
    }

    protected override Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.CriticalAsync(cancellationToken, cause, message);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.CriticalAsync(cancellationToken, message);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.CriticalAsync(cause, message);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.CriticalAsync(message);
    }
}