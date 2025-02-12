﻿namespace MooVC;

using Ardalis.GuardClauses;
using MooVC.Linq;
using static MooVC.ExceptionExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="Exception" />.
/// </summary>
public static partial class ExceptionExtensions
{
    /// <summary>
    /// Performs an action on the given <see cref="Exception" /> and any of its inner exceptions, recursively.
    /// </summary>
    /// <param name="exception">The <see cref="Exception" /> to perform the action on.</param>
    /// <param name="handler">The <see cref="Action{T}" /> to perform on the given exception.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="handler" /> parameter is <see langword="null" />.</exception>
    public static void Explode(this Exception? exception, Action<Exception> handler)
    {
        _ = Guard.Against.Null(handler, message: ExplodeHandlerRequired);

        exception.PerformExplode(handler);
    }

    /// <summary>
    /// Performs an action on the given <see cref="Exception" /> and any of its inner exceptions, recursively.
    /// </summary>
    /// <param name="exception">The <see cref="Exception" /> to perform the action on.</param>
    /// <param name="handler">The <see cref="Action{T}" /> to perform on the given exception.</param>
    private static void PerformExplode(this Exception? exception, Action<Exception> handler)
    {
        if (exception is not null)
        {
            handler(exception);

            if (exception is AggregateException aggregate)
            {
                aggregate.InnerExceptions.ForEach(inner => inner.PerformExplode(handler));
            }
            else
            {
                exception.InnerException.PerformExplode(handler);
            }
        }
    }
}