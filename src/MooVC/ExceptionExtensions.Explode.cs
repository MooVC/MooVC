namespace MooVC
{
    using System;
    using MooVC.Collections.Generic;

    public static class ExceptionExtensions
    {
        public static void Explode(this Exception? exception, Action<Exception> handler)
        {
            if (exception is { })
            {
                handler(exception);

                if (exception is AggregateException aggregate)
                {
                    aggregate.InnerExceptions.ForEach(ex => ex.Explode(handler));
                }
                else
                {
                    exception.InnerException.Explode(handler);
                }
            }
        }
    }
}