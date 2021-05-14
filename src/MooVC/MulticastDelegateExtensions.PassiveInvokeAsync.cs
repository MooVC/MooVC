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
}