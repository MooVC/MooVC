namespace MooVC;

using System;
using System.Reflection;
using MooVC.Collections.Generic;
using static MooVC.Resources;

/// <summary>
/// Provides methods to support event propagation.
/// </summary>
public static partial class MulticastDelegateExtensions
{
    /// <summary>
    /// Invokes a multicast delegate synchronously, with the option to handle any failures that may occur without throwing an exception.
    /// </summary>
    /// <typeparam name="TSender">The type of the sender from which the event has originated.</typeparam>
    /// <typeparam name="TArgs">The type of the event arguments.</typeparam>
    /// <param name="handler">The multicast delegate that holds the list of subscribers for the event.</param>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    /// <param name="onFailure">A delegate to be executed if any of the handlers throws an exception.</param>
    public static void PassiveInvoke<TSender, TArgs>(
        this MulticastDelegate? handler,
        TSender? sender,
        TArgs e,
        Action<AggregateException>? onFailure = default)
        where TSender : class
        where TArgs : EventArgs
    {
        if (handler is not null)
        {
            try
            {
                MethodInfo method = handler.GetMethodInfo();

                if (method.ReturnType != typeof(void))
                {
                    throw new NotSupportedException(MulticastDelegateExtensionsPassiveInvokeIncorrectReturnType);
                }

                EnsureParameters<TSender, TArgs>(method);

                handler
                    .GetInvocationList()
                    .ForAll(@delegate => @delegate.DynamicInvoke(sender, e));
            }
            catch (AggregateException ex)
            {
                onFailure?.Invoke(ex);
            }
        }
    }
}