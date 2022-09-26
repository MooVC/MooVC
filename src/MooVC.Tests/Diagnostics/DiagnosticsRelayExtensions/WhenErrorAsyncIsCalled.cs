namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class WhenErrorAsyncIsCalled
    : FireAndAwait
{
    public WhenErrorAsyncIsCalled()
        : base(Level.Error)
    {
    }

    protected override Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.ErrorAsync(cancellationToken, cause, message);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.ErrorAsync(cancellationToken, message);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.ErrorAsync(cause, message);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.ErrorAsync(message);
    }
}