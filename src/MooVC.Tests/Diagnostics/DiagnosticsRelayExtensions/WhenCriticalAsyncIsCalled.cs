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
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.CriticalAsync(cause, message, cancellationToken, args);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.CriticalAsync(message, cancellationToken, args);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.CriticalAsync(cause, message, args);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.CriticalAsync(message, args);
    }
}