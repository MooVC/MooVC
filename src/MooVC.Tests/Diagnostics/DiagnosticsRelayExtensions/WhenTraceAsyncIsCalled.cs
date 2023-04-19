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
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.TraceAsync(cause, message, cancellationToken, args);
    }

    protected override Task EmitWithCancellationTokenAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.TraceAsync(message, cancellationToken, args);
    }

    protected override Task EmitWithCauseAndMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.TraceAsync(cause, message, args);
    }

    protected override Task EmitWithMessageAsync(
        IDiagnosticsRelay? diagnostics,
        string message,
        Exception? cause = default,
        CancellationToken cancellationToken = default,
        params object[] args)
    {
        return diagnostics.TraceAsync(message, args);
    }
}