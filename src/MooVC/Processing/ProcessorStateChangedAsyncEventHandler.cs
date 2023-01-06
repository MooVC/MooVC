namespace MooVC.Processing;

using System.Threading.Tasks;

/// <summary>
/// Represents the method that will handle the <see cref="IProcessor.StateChanged"/> event.
/// </summary>
/// <param name="sender">The <see cref="IProcessor"/> that raised the event.</param>
/// <param name="e">An instance of <see cref="ProcessorStateChangedAsyncEventArgs"/> containing information about the state change.</param>
/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
public delegate Task ProcessorStateChangedAsyncEventHandler(IProcessor sender, ProcessorStateChangedAsyncEventArgs e);