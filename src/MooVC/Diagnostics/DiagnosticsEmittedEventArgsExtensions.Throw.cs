namespace MooVC.Diagnostics;

using System;
using System.Collections.Generic;
using System.Linq;
using static MooVC.Diagnostics.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extension methods for the <see cref="DiagnosticsEmittedEventArgs"/> class.
/// </summary>
public static class DiagnosticsEmittedEventArgsExtensions
{
    /// <summary>
    /// Throws an <see cref="AggregateException"/> if any emitted diagnostics are equal to or greater in severity to the
    /// specified <see cref="Level"/>.
    /// </summary>
    /// <param name="diagnostics">The collection of <see cref="DiagnosticsEmittedAsyncEventArgs"/> objects to evaluate.</param>
    /// <param name="level">The minimum <see cref="Level"/> required for a diagnostic to be considered a match.</param>
    /// <param name="message">An optional message to include in the thrown <see cref="AggregateException"/>.</param>
    public static void Throw(
        this IEnumerable<DiagnosticsEmittedAsyncEventArgs>? diagnostics,
        Level level = Level.Warning,
        string? message = default)
    {
        diagnostics.Throw((diagnostic, _) => diagnostic.Level >= level, message: message);
    }

    /// <summary>
    /// Throws an <see cref="AggregateException"/> if any emitted diagnostics match the specified <see cref="predicate"/>.
    /// </summary>
    /// <param name="diagnostics">The collection of <see cref="DiagnosticsEmittedAsyncEventArgs"/> objects to evaluate.</param>
    /// <param name="predicate">A function to test each diagnostics for a condition. Only diagnostics that satisfy the condition will
    /// be included in the <see cref="AggregateException"/>.</param>
    /// <param name="message">An optional message to include in the thrown <see cref="AggregateException"/>.</param>
    /// <exception cref="AggregateException">Thrown if one or more diagnostics satisfy the specified <see cref="predicate"/>.</exception>
    public static void Throw(
        this IEnumerable<DiagnosticsEmittedAsyncEventArgs>? diagnostics,
        Func<DiagnosticsEmittedAsyncEventArgs, Exception, bool> predicate,
        string? message = default)
    {
        if (diagnostics is { })
        {
            _ = IsNotNull(predicate, message: DiagnosticsEmittedEventArgsExtensionsThrowPredicateRequired);

            IEnumerable<Exception> matches = diagnostics
                .Where(diagnostic => diagnostic.Cause is { })
                .Where(diagnostic => predicate(diagnostic, diagnostic.Cause!))
                .Select(diagnostic => diagnostic.Cause!)
                .ToArray();

            if (matches.Any())
            {
                throw new AggregateException(message, matches.ToArray());
            }
        }
    }
}