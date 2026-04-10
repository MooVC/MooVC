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
    /// Executes an action for each element in <paramref name="enumerable"/> and returns the original subject.
    /// </summary>
    /// <typeparam name="T">The subject type.</typeparam>
    /// <typeparam name="TEnumerable">The element type to iterate over.</typeparam>
    /// <param name="subject">The subject instance preserved for fluent chaining.</param>
    /// <param name="action">The action to execute for each item.</param>
    /// <param name="enumerable">The sequence to iterate over.</param>
    /// <returns>The original <paramref name="subject"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="subject"/>, <paramref name="action"/>, or <paramref name="enumerable"/> is <see langword="null"/>.
    /// </exception>
    public static T Enumerate<T, TEnumerable>(this T subject, Action<TEnumerable> action, IEnumerable<TEnumerable> enumerable)
    {
        _ = Guard.Against.Null(enumerable, message: EnumerateEnumerableRequired);

        return subject.Enumerate(action, _ => enumerable);
    }

    /// <summary>
    /// Executes an action for each element in <paramref name="enumerable"/> and returns the original subject.
    /// </summary>
    /// <typeparam name="T">The subject type.</typeparam>
    /// <typeparam name="TEnumerable">The element type to iterate over.</typeparam>
    /// <param name="subject">The subject instance preserved for fluent chaining.</param>
    /// <param name="action">The action to execute for each item.</param>
    /// <param name="enumerable">The sequence to iterate over.</param>
    /// <returns>The original <paramref name="subject"/> instance.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="subject"/>, <paramref name="action"/>, or <paramref name="enumerable"/> is <see langword="null"/>.
    /// </exception>
    public static T Enumerate<T, TEnumerable>(this T subject, Action<TEnumerable> action, Func<T, IEnumerable<TEnumerable>> enumerable)
    {
        _ = Guard.Against.Null(action, message: EnumerateActionRequired);
        _ = Guard.Against.Null(enumerable, message: EnumerateEnumerableRequired);

        return subject.Enumerate(
            (element, _) =>
            {
                action(element);

                return _;
            },
            enumerable);
    }

    /// <summary>
    /// Executes a projection for each element in <paramref name="enumerable"/> and returns the final projected subject.
    /// </summary>
    /// <typeparam name="T">The subject type.</typeparam>
    /// <typeparam name="TEnumerable">The element type to iterate over.</typeparam>
    /// <param name="subject">The initial subject instance.</param>
    /// <param name="action">The projection applied for each item, receiving the item and current subject.</param>
    /// <param name="enumerable">The sequence to iterate over.</param>
    /// <returns>The resulting subject after all projections have been applied.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="subject"/>, <paramref name="action"/>, or <paramref name="enumerable"/> is <see langword="null"/>.
    /// </exception>
    public static T Enumerate<T, TEnumerable>(this T subject, Func<TEnumerable, T, T> action, IEnumerable<TEnumerable> enumerable)
    {
        _ = Guard.Against.Null(enumerable, message: EnumerateEnumerableRequired);

        return subject.Enumerate(action, _ => enumerable);
    }

    /// <summary>
    /// Executes a projection for each element in <paramref name="enumerable"/> and returns the final projected subject.
    /// </summary>
    /// <typeparam name="T">The subject type.</typeparam>
    /// <typeparam name="TEnumerable">The element type to iterate over.</typeparam>
    /// <param name="subject">The initial subject instance.</param>
    /// <param name="action">The projection applied for each item, receiving the item and current subject.</param>
    /// <param name="enumerable">The sequence to iterate over.</param>
    /// <returns>The resulting subject after all projections have been applied.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="subject"/>, <paramref name="action"/>, or <paramref name="enumerable"/> is <see langword="null"/>.
    /// </exception>
    public static T Enumerate<T, TEnumerable>(this T subject, Func<TEnumerable, T, T> action, Func<T, IEnumerable<TEnumerable>> enumerable)
    {
        _ = Guard.Against.Null(subject, message: EnumerateSubjectRequired);
        _ = Guard.Against.Null(action, message: EnumerateActionRequired);
        _ = Guard.Against.Null(enumerable, message: EnumerateEnumerableRequired);

        foreach (TEnumerable item in enumerable(subject))
        {
            subject = action(item, subject);
        }

        return subject;
    }
}