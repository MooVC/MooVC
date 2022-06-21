namespace MooVC;

using System;
using MooVC.Collections.Generic;
using static MooVC.Ensure;
using static MooVC.Resources;

public static class ExceptionExtensions
{
    public static void Explode(this Exception? exception, Action<Exception> handler)
    {
        _ = ArgumentNotNull(
            handler,
            nameof(handler),
            ExceptionExtensionsExplodeHandlerRequired);

        exception?.PerformExplode(handler);
    }

    private static void PerformExplode(this Exception? exception, Action<Exception> handler)
    {
        if (exception is { })
        {
            handler(exception);

            if (exception is AggregateException aggregate)
            {
                aggregate.InnerExceptions.ForEach(ex => ex.PerformExplode(handler));
            }
            else
            {
                exception.InnerException.PerformExplode(handler);
            }
        }
    }
}