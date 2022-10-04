namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class WhenDebugAsyncIsCalled
    : FireAndAwait
{
    public WhenDebugAsyncIsCalled()
        : base(Level.Debug)
    {
    }

    protected override Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        return diagnostics.DebugAsync(cancellationToken, cause, message, args);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        return diagnostics.DebugAsync(cancellationToken, message, args);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        return diagnostics.DebugAsync(cause, message, args);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        return diagnostics.DebugAsync(message, args);
    }
}