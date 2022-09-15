namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IDiagnosticsProxy
{
    event DiagnosticsEmittedAsyncEventHandler? DiagnosticsEmitted;

    Task EmitAsync<T>(
        T source,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Level? level = default,
        string? message = default)
        where T : class, IEmitDiagnostics;
}