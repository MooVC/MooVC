namespace MooVC
{
    using System;
    using System.Reflection;
    using MooVC.Collections.Generic;
    using static MooVC.Resources;

    public static partial class MulticastDelegateExtensions
    {
        public static void PassiveInvoke<TSender, TArgs>(
            this MulticastDelegate? handler,
            TSender? sender,
            TArgs e,
            Action<AggregateException>? onFailure = default)
            where TSender : class
            where TArgs : EventArgs
        {
            if (handler is { })
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
}