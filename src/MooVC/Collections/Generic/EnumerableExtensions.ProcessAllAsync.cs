namespace MooVC.Collections.Generic;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions relating to IEnumerable{T}.
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
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the task is an enumerable sequence
    /// containing the results of the transform function applied to each element of the source sequence.</returns>
    public static async Task<IEnumerable<TResult>> ProcessAllAsync<TResult, TSource>(
        this IEnumerable<TSource>? source,
        Func<TSource, Task<TResult>> transform)
        where TSource : notnull
    {
        if (source is { })
        {
            _ = IsNotNull(transform, message: EnumerableExtensionsProcessAllTransformRequired);

            return await source
                .ProcessAllAsync(
                    async source =>
                    {
                        TResult result = await transform(source)
                            .ConfigureAwait(false);

                        if (result is { })
                        {
                            return new[] { result };
                        }

                        return Enumerable.Empty<TResult>();
                    })
                .ConfigureAwait(false);
        }

        return Enumerable.Empty<TResult>();
    }

    /// <summary>
    /// Asyncrhonously processes the elements of an enumerable sequence, returning the aggregate results of the transformation function applied
    /// to each element.
    /// </summary>
    /// <typeparam name="TResult">The type of the results of the transform function.</typeparam>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">The sequence of elements to transform.</param>
    /// <param name="transform">The function to apply to each element of the sequence.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the task is an enumerable sequence containing
    /// the results of the transform function applied to each element of the source sequence.</returns>
    public static async Task<IEnumerable<TResult>> ProcessAllAsync<TSource, TResult>(
        this IEnumerable<TSource>? source,
        Func<TSource, Task<IEnumerable<TResult>>> transform)
        where TSource : notnull
    {
        if (source is { })
        {
            _ = IsNotNull(transform, message: EnumerableExtensionsProcessAllTransformRequired);

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
                .Where(transform => transform is { })
                .SelectMany(transform => transform)
                .ToArray();
        }

        return Enumerable.Empty<TResult>();
    }
}