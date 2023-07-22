namespace MooVC.Hosting;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MooVC.Collections.Generic;
using static MooVC.Hosting.ThreadSafeHostedService_Resources;

/// <summary>
/// Allows for the thread-safe start/stop of one or more <see cref="IHostedService"/> implementations.
/// </summary>
public sealed class ThreadSafeHostedService
    : IHostedService
{
    private const int Started = 1;
    private const int Stopped = 0;

    private static readonly Action<ILogger, Exception> logTryStopAsyncFailure = LoggerMessage.Define(
        LogLevel.Warning,
        new EventId(1, name: nameof(TryStopAsync)),
        TryStopAsyncFailure);

    private readonly ILogger<ThreadSafeHostedService> logger;
    private readonly IEnumerable<IHostedService> services;
    private int state = Stopped;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThreadSafeHostedService"/> class.
    /// </summary>
    /// <param name="logger">
    /// The logger provider, used to inform observers of happenings within the service that do not directly result in an outcome being propagated to the caller.
    /// </param>
    /// <param name="services">
    /// The instances of <see cref="IHostedService"/> to be managed by the <see cref="ThreadSafeHostedService"/>.
    /// </param>
    public ThreadSafeHostedService(ILogger<ThreadSafeHostedService> logger, IEnumerable<IHostedService> services)
    {
        this.logger = Guard.Against.Null(logger, parameterName: nameof(logger), message: LoggerRequired);
        this.services = Guard.Against.Null(services, parameterName: nameof(services), message: ServicesRequired);
    }

    /// <summary>
    /// Starts the contained services asynchronously, ensuring no more than one caller can trigger start at the same time.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (Interlocked.CompareExchange(ref state, Started, Stopped) == Stopped)
        {
            try
            {
                await PerformStartAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                await TryStopAsync(cancellationToken)
                    .ConfigureAwait(false);

                _ = Interlocked.Exchange(ref state, Stopped);

                throw;
            }
        }
    }

    /// <summary>
    /// Stops the contained services asynchronously, ensuring no more than one caller can trigger start at the same time.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (Interlocked.CompareExchange(ref state, Stopped, Started) == Started)
        {
            try
            {
                await PerformStopAsync(cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                _ = Interlocked.Exchange(ref state, Started);

                throw;
            }
        }
    }

    private Task PerformStartAsync(CancellationToken cancellationToken)
    {
        return services.ForAllAsync(service => service.StartAsync(cancellationToken));
    }

    private Task PerformStopAsync(CancellationToken cancellationToken)
    {
        return services.ForAllAsync(service => service.StopAsync(cancellationToken));
    }

    private async Task TryStopAsync(CancellationToken cancellationToken)
    {
        try
        {
            await PerformStopAsync(cancellationToken)
                .ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logTryStopAsyncFailure(logger, ex);
        }
    }
}