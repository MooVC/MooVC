﻿namespace MooVC.Linq;

using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Linq.IEnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Synchronously processes the elements of an enumerable sequence, returning the results of the transformation function applied to each element.
    /// </summary>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>A readonly list containing the results of the transform function applied to each element of the source sequence.</returns>
    public static IReadOnlyList<TResult> Process<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, TResult> transform)
        where TSource : notnull
    {
        if (source is null)
        {
            return [];
        }

        _ = Guard.Against.Null(transform, message: ProcessTransformRequired);

        return source.Process(
            source =>
            {
                TResult result = transform(source);

                if (result is null)
                {
                    return [];
                }

                return result.AsEnumerable();
            });
    }

    /// <summary>
    /// Synchronously processes the elements of an enumerable sequence, returning the aggregated results of the transformation function
    /// applied to each element.
    /// </summary>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>A readonly list containing the results of the transform function applied to each element of the source sequence.</returns>
    public static IReadOnlyList<TResult> Process<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, IEnumerable<TResult>> transform)
        where TSource : notnull
    {
        Dictionary<TSource, IEnumerable<TResult>>? transforms = default;

        return source.Process(
            (item, results) => transforms![item] = results,
            () => transforms!,
            ForEach,
            () => transforms = [],
            transform);
    }

    private static TResult[] Process<TResult, TSource>(
        this IEnumerable<TSource>? source,
        Action<TSource, IEnumerable<TResult>> add,
        Func<IDictionary<TSource, IEnumerable<TResult>>> commit,
        Action<IEnumerable<TSource>?, Action<TSource>> enumerator,
        Action initialize,
        Func<TSource, IEnumerable<TResult>> transform)
    {
        if (source is null)
        {
            return [];
        }

        _ = Guard.Against.Null(transform, message: ProcessTransformRequired);

        source = source.ToArrayOrEmpty();

        initialize();
        enumerator(source, item => add(item, transform(item)));

        IDictionary<TSource, IEnumerable<TResult>> transforms = commit();

        return source
            .Select(original => transforms[original])
            .Where(transform => transform is not null)
            .SelectMany(result => result)
            .ToArray();
    }
}