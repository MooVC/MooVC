namespace MooVC.Linq;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using static MooVC.Collections.Generic.Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Asyncrhonously processes the elements of an enumerable sequence, returning the results of the transformation function applied
    /// to each element.
    /// </summary>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>
    /// A <see cref="Task{IReadOnlyList{TResult}}" /> representing the asynchronous operation.
    /// The result of the task is an enumerable sequence containing the results of the transform function applied to each element of the
    /// source sequence.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<IReadOnlyList<TResult>> ProcessAllAsync<TResult, TSource>(
        this IEnumerable<TSource>? source,
        Func<TSource, Task<TResult>> transform)
        where TSource : notnull
    {
        if (source is null)
        {
            return Array.Empty<TResult>();
        }

        _ = Guard.Against.Null(transform, parameterName: nameof(transform), message: EnumerableExtensionsProcessAllTransformRequired);

        return await source
            .ProcessAllAsync(
                async source =>
                {
                    TResult result = await transform(source)
                        .ConfigureAwait(false);

                    if (result is null)
                    {
                        return Enumerable.Empty<TResult>();
                    }

                    return result.ToEnumerable();
                })
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Asyncrhonously processes the elements of an enumerable sequence, returning the aggregate results of the transformation function applied
    /// to each element.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source" />.</typeparam>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>
    /// A <see cref="Task{IReadOnlyList{{TResult}}" /> representing the asynchronous operation.
    /// The result of the task is an enumerable sequence containing the results of the transform function applied to each element of the
    /// source sequence.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<IReadOnlyList<TResult>> ProcessAllAsync<TSource, TResult>(
        this IEnumerable<TSource>? source,
        Func<TSource, Task<IEnumerable<TResult>>> transform)
        where TSource : notnull
    {
        if (source is null)
        {
            return Array.Empty<TResult>();
        }

        _ = Guard.Against.Null(transform, parameterName: nameof(transform), message: EnumerableExtensionsProcessAllTransformRequired);

        var transforms = new ConcurrentDictionary<TSource, IEnumerable<TResult>>();

        source = source.Snapshot();

        await source
            .ForAllAsync(async item =>
            {
                IEnumerable<TResult> results = await transform(item)
                    .ConfigureAwait(false);

                transforms[item] = results;
            })
            .ConfigureAwait(false);

        return source
            .Select(original => transforms[original])
            .Where(transform => transform is not null)
            .SelectMany(transform => transform)
            .ToArray();
    }
}