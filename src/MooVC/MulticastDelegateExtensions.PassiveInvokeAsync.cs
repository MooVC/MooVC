namespace MooVC;

using System;
using System.Threading.Tasks;

/// <summary>
/// Provides methods to support event propagation.
/// </summary>
public static partial class MulticastDelegateExtensions
{
    /// <summary>
    /// Invokes a multicast delegate asynchronously, with the option to handle any failures that may occur without throwing an exception.
    /// The multicast delegate is assumed to be a derivation of the AsyncEventHandler.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender from which the event has originated.</typeparam>
    /// <typeparam name="TArgs">The type of the event arguments.</typeparam>
    /// <param name="handler">The multicast delegate that holds the list of subscribers for the event.</param>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    /// <param name="onFailure">A delegate to be executed if any of the handlers throws an exception.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task PassiveInvokeAsync<TSender, TArgs>(
        this MulticastDelegate? handler,
        TSender? sender,
        TArgs e,
        Func<AggregateException, Task>? onFailure = default)
        where TSender : class
        where TArgs : AsyncEventArgs
    {
        try
        {
            await handler
                .InvokeAsync(sender, e)
                .ConfigureAwait(false);
        }
        catch (AggregateException ex)
        {
            if (onFailure is { })
            {
                await onFailure(ex)
                    .ConfigureAwait(false);
            }
        }
    }
}