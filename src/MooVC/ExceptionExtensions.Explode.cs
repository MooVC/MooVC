namespace MooVC;

using System;
using MooVC.Collections.Generic;
using static MooVC.Ensure;
using static MooVC.Resources;

/// <summary>
/// Provides extensions relating to Exception.
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    /// Performs an action on the given exception and any of its inner exceptions,
    /// recursively.
    /// </summary>
    /// <param name="exception">The exception to perform the action on.</param>
    /// <param name="handler">The action to perform on the given exception.</param>
    /// <exception cref="ArgumentNullException">
    /// The <paramref name="handler"/> parameter is null.
    /// </exception>
    public static void Explode(this Exception? exception, Action<Exception> handler)
    {
        _ = IsNotNull(handler, message: ExceptionExtensionsExplodeHandlerRequired);

        exception.PerformExplode(handler);
    }

    /// <summary>
    /// Performs an action on the given exception and any of its inner exceptions,
    /// recursively.
    /// </summary>
    /// <param name="exception">The exception to perform the action on.</param>
    /// <param name="handler">The action to perform on the given exception.</param>
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