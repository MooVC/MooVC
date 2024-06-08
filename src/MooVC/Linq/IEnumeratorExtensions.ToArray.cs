namespace MooVC.Linq;

using System.Collections;
using Ardalis.GuardClauses;
using static MooVC.Linq.IEnumeratorExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerator" />.
/// </summary>
public static partial class IEnumeratorExtensions
{
    /// <summary>
    /// Enumerates an instance of <paramref name="enumerator"/> to return an array with its contents.
    /// </summary>
    /// <param name="enumerator">The <see cref="IEnumerator"/> to enumerate.</param>
    /// <returns>An array of elements contained within the <paramref name="enumerator"/>.</returns>
    public static object[] ToArray(this IEnumerator enumerator)
    {
        return enumerator.PerformToArray(enumerator => enumerator.Current);
    }

    /// <summary>
    /// Enumerates an instance of <paramref name="enumerator"/> to return an array with its contents.
    /// </summary>
    /// <param name="enumerator">The <see cref="IEnumerator{T}"/> to enumerate.</param>
    /// <typeparam name="T">The type of the elements contained within the <paramref name="enumerator"/>.</typeparam>
    /// <returns>An array of elements contained within the <paramref name="enumerator"/>.</returns>
    public static T[] ToArray<T>(this IEnumerator<T> enumerator)
    {
        return enumerator.PerformToArray(enumerator => enumerator.Current);
    }

    private static T[] PerformToArray<T, TEnumerator>(this TEnumerator enumerator, Func<TEnumerator, T> selector)
        where TEnumerator : IEnumerator
    {
        _ = Guard.Against.Null(enumerator, message: PerformToArrayEnumeratorRequired);
        var list = new List<T>();

        while (enumerator.MoveNext())
        {
            T current = selector(enumerator);

            list.Add(current);
        }

        return [.. list];
    }
}