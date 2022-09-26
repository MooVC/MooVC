namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;
using System.Threading.Tasks;

public sealed class WhenTraceAsyncIsCalled
    : FireAndAwait
{
    public WhenTraceAsyncIsCalled()
        : base(Level.Trace)
    {
    }

    protected override Task EmitWithAllAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.TraceAsync(cancellationToken, cause, message);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.TraceAsync(cancellationToken, message);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.TraceAsync(cause, message);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default)
    {
        return diagnostics.TraceAsync(message);
    }
}