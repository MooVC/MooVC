﻿namespace MooVC.Diagnostics.DiagnosticsRelayExtensions;

using System;
using System.Threading;

public sealed class WhenCriticalIsCalled
    : FireAndForget
{
    public WhenCriticalIsCalled()
        : base(Level.Critical)
    {
    }

    protected override void EmitWithAll(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        diagnostics.Critical(cancellationToken, cause, message, args);
    }

    protected override void EmitWithCancellationTokenAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        diagnostics.Critical(cancellationToken, message, args);
    }

    protected override void EmitWithCauseAndMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        diagnostics.Critical(cause, message, args);
    }

    protected override void EmitWithMessage(
        IDiagnosticsRelay? diagnostics,
        string message,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        params object[] args)
    {
        diagnostics.Critical(message, args);
    }
}