namespace MooVC
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using static System.String;
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

                ParameterInfo[] parameters = method.GetParameters();

                if (parameters.Length != 2)
                {
                    throw new NotSupportedException(MulticastDelegateExtensionsInvokeAsyncIncorrectNumberOfParameters);
                }

                Type senderType = typeof(TSender);

                if (!parameters[0].ParameterType.IsAssignableFrom(senderType))
                {
                    throw new NotSupportedException(Format(
                        MulticastDelegateExtensionsInvokeAsyncIncorrectSenderParameterType,
                        senderType.FullName));
                }

                Type argsType = typeof(TArgs);

                if (!parameters[1].ParameterType.IsAssignableFrom(argsType))
                {
                    throw new NotSupportedException(Format(
                        MulticastDelegateExtensionsInvokeAsyncIncorrectArgsParameterType,
                        argsType.FullName));
                }

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