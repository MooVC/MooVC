namespace MooVC;

using System;
using System.Reflection;
using System.Threading.Tasks;
using MooVC.Collections.Generic;
using static MooVC.Resources;

/// <summary>
/// Provides methods to support event propagation.
/// </summary>
public static partial class MulticastDelegateExtensions
{
    /// <summary>
    /// Invokes a multicast delegate asynchronously.
    /// The multicast delegate is assumed to be a derivation of the AsyncEventHandler.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender from which the event has originated.</typeparam>
    /// <typeparam name="TArgs">The type of the event arguments.</typeparam>
    /// <param name="handler">The multicast delegate that holds the list of subscribers for the event.</param>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public static async Task InvokeAsync<TSender, TArgs>(this MulticastDelegate? handler, TSender? sender, TArgs e)
        where TSender : class
        where TArgs : AsyncEventArgs
    {
        if (handler is { })
        {
            MethodInfo method = handler.GetMethodInfo();

            if (method.ReturnType != typeof(Task))
            {
                throw new NotSupportedException(MulticastDelegateExtensionsInvokeAsyncIncorrectReturnType);
            }

            EnsureParameters<TSender, TArgs>(method);

            Delegate[] delegates = handler.GetInvocationList();

            Func<Task>[] handlers = Array.ConvertAll<Delegate, Func<Task>>(
                delegates,
                @delegate => () => (Task)@delegate.DynamicInvoke(sender, e)!);

            await handlers
                .ForAllAsync(handler => handler())
                .ConfigureAwait(false);
        }
    }
}