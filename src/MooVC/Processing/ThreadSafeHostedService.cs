namespace MooVC.Processing;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MooVC.Collections.Generic;
using MooVC.Diagnostics;
using static MooVC.Ensure;
using static MooVC.Processing.Resources;

/// <summary>
/// Allows for the thread-safe start/stop of one or more <see cref="IHostedService"/> implementations.
/// </summary>
public sealed class ThreadSafeHostedService
    : ThreadSafeProcessor
{
    private readonly IEnumerable<IHostedService> services;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadSafeHostedService"/> class.
    /// </summary>
    /// <param name="services">
    /// The services to be managed by the <see cref="ThreadSafeHostedService"/>.
    /// </param>
    /// <param name="diagnostics">
    /// The proxy that determines if diagnostics are to be emitted, with the default configuration used if not provided.
    /// </param>
    public ThreadSafeHostedService(IEnumerable<IHostedService> services, IDiagnosticsProxy? diagnostics = default)
        : base(diagnostics: diagnostics)
    {
        this.services = IsNotEmpty(services, message: ThreadSafeHostedServiceServicesRequired);
    }

    /// <summary>
    /// Asynchronously starts all <see cref="IHostedService"/> instances managed by the processor.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected override Task PerformStartAsync(CancellationToken cancellationToken)
    {
        return services.ForAllAsync(service => service.StartAsync(cancellationToken));
    }

    /// <summary>
    /// Asynchronously stops all <see cref="IHostedService"/> instances managed by the processor.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    protected override Task PerformStopAsync(CancellationToken cancellationToken)
    {
        return services.ForAllAsync(service => service.StopAsync(cancellationToken));
    }
}