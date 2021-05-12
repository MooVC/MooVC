namespace MooVC
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using static MooVC.Resources;

    public static partial class MulticastDelegateExtensions
    {
        public static async Task InvokeAsync<TSender, TArgs>(
            this MulticastDelegate? handler,
            TSender? sender,
            TArgs e)
            where TSender : class
            where TArgs : EventArgs
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

                await Task
                    .WhenAll(handlers.Select(handler => handler()))
                    .ConfigureAwait(false);
            }
        }
    }
}