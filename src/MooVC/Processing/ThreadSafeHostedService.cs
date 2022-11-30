﻿namespace MooVC.Processing;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MooVC.Collections.Generic;
using MooVC.Diagnostics;
using static MooVC.Ensure;
using static MooVC.Processing.Resources;

public sealed class ThreadSafeHostedService
    : ThreadSafeProcessor
{
    private readonly IEnumerable<IHostedService> services;

    public ThreadSafeHostedService(IEnumerable<IHostedService> services, IDiagnosticsProxy? diagnostics = default)
        : base(diagnostics: diagnostics)
    {
        this.services = IsNotEmpty(services, message: ThreadSafeHostedServiceServicesRequired);
    }

    protected override Task PerformStartAsync(CancellationToken cancellationToken)
    {
        return services.ForAllAsync(service => service.StartAsync(cancellationToken));
    }

    protected override Task PerformStopAsync(CancellationToken cancellationToken)
    {
        return services.ForAllAsync(service => service.StopAsync(cancellationToken));
    }
}