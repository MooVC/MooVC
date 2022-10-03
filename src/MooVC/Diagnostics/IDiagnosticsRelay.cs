﻿namespace MooVC.Diagnostics;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IDiagnosticsRelay
    : IEmitDiagnostics
{
    Task EmitAsync(
        CancellationToken? cancellationToken = default,
        Exception? cause = default,
        Impact? impact = default,
        Level? level = default,
        DiagnosticsMessage? message = default);
}