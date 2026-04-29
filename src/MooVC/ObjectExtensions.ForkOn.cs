namespace MooVC;

using System;
using Ardalis.GuardClauses;
using static MooVC.ObjectExtensions_Resources;

/// <summary>
/// Provides extensions relating to object.
/// </summary>
public static partial class ObjectExtensions
{
    /// <summary>
    /// Facilitates branching logic based on a predicate evaluation.
    /// </summary>
    /// <typeparam name="T">The type upon which the logic is being applied.</typeparam>
    /// <typeparam name="TResult">The type returned following the Fork operation.</typeparam>
    /// <param name="subject">The instance upon which the logic is being applied.</param>
    /// <param name="predicate">The condition that determines which path to take.</param>
    /// <param name="true">The path to be taken when <paramref name="predicate"/> yields <see langword="true"/>.</param>
    /// <param name="false">The path to be taken when <paramref name="predicate"/> yields <see langword="false"/>.</param>
    /// <remarks>At least one of the optional arguments, <paramref name="true"/> or <paramref name="false"/> must be provided.</remarks>
    /// <returns>The <paramref name="subject"/> instance following application of the appropriate path.</returns>
    public static TResult ForkOn<T, TResult>(this T subject, Predicate<T> predicate, Func<T, TResult> @true, Func<T, TResult> @false)
    {
        _ = Guard.Against.Null(subject, message: ForkOnSubjectRequired);
        _ = Guard.Against.Null(predicate, message: ForkOnPredicateRequired);
        _ = Guard.Against.Null(@true, message: ForkOnPathsRequired);
        _ = Guard.Against.Null(@false, message: ForkOnPathsRequired);

        if (predicate(subject))
        {
            return @true(subject);
        }

        return @false(subject);
    }
}