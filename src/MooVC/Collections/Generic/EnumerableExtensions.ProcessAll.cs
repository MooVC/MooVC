namespace MooVC.Collections.Generic;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Asyncrhonously processes the elements of an enumerable sequence, returning the results of the transformation function applied
    /// to each element.
    /// </summary>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>A readonly list containing the results of the transform function applied to each element of the source sequence.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<TResult> ProcessAll<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, TResult> transform)
        where TSource : notnull
    {
        if (source is null)
        {
            return Array.Empty<TResult>();
        }

        _ = IsNotNull(transform, argumentName: nameof(transform), message: EnumerableExtensionsProcessAllTransformRequired);

        return source.ProcessAll(
            source =>
            {
                TResult result = transform(source);

                if (result is null)
                {
                    return Enumerable.Empty<TResult>();
                }

                return result.AsEnumerable();
            });
    }

    /// <summary>
    /// Asynchronously processes the elements of an enumerable sequence, returning the aggregated results of the transformation function
    /// applied to each element.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>A readonly list containing the results of the transform function applied to each element of the source sequence.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IReadOnlyList<TResult> ProcessAll<TSource, TResult>(this IEnumerable<TSource>? source, Func<TSource, IEnumerable<TResult>> transform)
        where TSource : notnull
    {
        ConcurrentDictionary<TSource, IEnumerable<TResult>>? transforms = default;

        return source.Process(
            (item, results) => transforms![item] = results,
            () => transforms!,
            ForAll,
            () => transforms = new ConcurrentDictionary<TSource, IEnumerable<TResult>>(),
            transform);
    }
}