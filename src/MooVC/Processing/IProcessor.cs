namespace MooVC.Processing;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

/// <summary>
/// Represents a long running process.
/// </summary>
public interface IProcessor
    : IHostedService
{
    /// <summary>
    /// An event that is raised when the state of the processor changes.
    /// </summary>
    event ProcessorStateChangedAsyncEventHandler StateChanged;

    /// <summary>
    /// Gets the current state of the processor.
    /// </summary>
    /// <value>
    /// The current state of the processor.
    /// </value>
    ProcessorState State { get; }

    /// <summary>
    /// Tries to start the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation. The result of the task is a boolean value
    /// indicating whether the attempt to start the processor was successful.</returns>
    Task<bool> TryStartAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Tries to stop the processor asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken" /> that can be used to cancel the operation.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation. The result of the task is a boolean value
    /// indicating whether the attempt to stop the processor was successful.</returns>
    Task<bool> TryStopAsync(CancellationToken cancellationToken);
}