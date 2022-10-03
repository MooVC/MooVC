namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IDiagnosticsProxy
    : IEmitDiagnostics
{
    Level this[Impact impact] { get; }

    Task EmitAsync(
        IEmitDiagnostics source,
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default);
}