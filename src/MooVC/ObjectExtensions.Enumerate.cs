namespace MooVC;

using System;
using Ardalis.GuardClauses;
using MooVC.Linq;
using static MooVC.ObjectExtensions_Resources;

/// <summary>
/// Provides extensions relating to object.
/// </summary>
public static partial class ObjectExtensions
{
    public static T Enumerate<T, TEnumerable>(this T subject, Action<TEnumerable> action, IEnumerable<TEnumerable> enumerable)
    {
        _ = Guard.Against.Null(subject, message: ForkOnSubjectRequired);
        _ = Guard.Against.Null(action, message: ForkOnPredicateRequired);
        _ = Guard.Against.Null(enumerable, message: ForkOnPathsRequired);

        foreach (TEnumerable item in enumerable)
        {
            action(item);
        }

        return subject;
    }

    public static T Enumerate<T, TEnumerable>(this T subject, Func<TEnumerable, T, T> action, IEnumerable<TEnumerable> enumerable)
    {
        _ = Guard.Against.Null(subject, message: ForkOnSubjectRequired);
        _ = Guard.Against.Null(action, message: ForkOnPredicateRequired);
        _ = Guard.Against.Null(enumerable, message: ForkOnPathsRequired);

        foreach (TEnumerable item in enumerable)
        {
            subject = action(item, subject);
        }

        return subject;
    }
}