namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static async Task<IEnumerable<TResult>> ProcessAllAsync<TResult, TSource>(
            this IEnumerable<TSource>? source,
            Func<TSource, Task<TResult>> transform)
        {
            if (source is { })
            {
                _ = ArgumentNotNull(
                    transform,
                    nameof(transform),
                    EnumerableExtensionsProcessAllTransformRequired);

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

        public static async Task<IEnumerable<TResult>> ProcessAllAsync<TSource, TResult>(
            this IEnumerable<TSource>? source,
            Func<TSource, Task<IEnumerable<TResult>>> transform)
        {
            if (source is { })
            {
                _ = ArgumentNotNull(
                    transform,
                    nameof(transform),
                    EnumerableExtensionsProcessAllTransformRequired);

                var transforms = new ConcurrentDictionary<TSource, IEnumerable<TResult>>();

                await source
                    .ForAllAsync(async item =>
                    {
                        IEnumerable<TResult> results = await transform(item)
                            .ConfigureAwait(false);

                        transforms[item] = results;
                    })
                    .ConfigureAwait(false);

                return transforms
                    .Values
                    .Where(transform => transform is { })
                    .SelectMany(transform => transform)
                    .ToArray();
            }

            return Enumerable.Empty<TResult>();
        }
    }
}