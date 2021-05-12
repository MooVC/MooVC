namespace MooVC
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    public static partial class MulticastDelegateExtensions
    {
        public static async Task PassiveInvokeAsync<TSender, TArgs>(
            this MulticastDelegate? handler,
            TSender? sender,
            TArgs e,
            Action<TargetInvocationException>? onFailure = default)
            where TSender : class
            where TArgs : EventArgs
        {
            try
            {
                await handler
                    .InvokeAsync(sender, e)
                    .ConfigureAwait(false);
            }
            catch (TargetInvocationException tie)
            {
                onFailure?.Invoke(tie);
            }
        }
    }
}