namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IDiagnosticsProxy
{
    event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    Level this[Impact impact] { get; }

    Task EmitAsync<T>(
        T source,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        string? message = default)
        where T : class, IEmitDiagnostics;
}