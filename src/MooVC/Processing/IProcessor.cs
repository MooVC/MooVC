namespace MooVC.Processing;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public interface IProcessor
    : IHostedService
{
    event ProcessorStateChangedAsyncEventHandler StateChanged;

    ProcessorState State { get; }

    Task<bool> TryStartAsync(CancellationToken cancellationToken);

    Task<bool> TryStopAsync(CancellationToken cancellationToken);
}