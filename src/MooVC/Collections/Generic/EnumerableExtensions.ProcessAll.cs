namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> ProcessAll<TResult, TSource>(
            this IEnumerable<TSource>? source,
            Func<TSource, TResult> transform)
        {
            if (source is { })
            {
                _ = ArgumentNotNull(
                    transform,
                    nameof(transform),
                    EnumerableExtensionsProcessAllTransformRequired);

                return source.ProcessAll(
                    source =>
                    {
                        TResult result = transform(source);

                        if (result is { })
                        {
                            return new[] { result };
                        }

                        return Enumerable.Empty<TResult>();
                    });
            }

            return Enumerable.Empty<TResult>();
        }

        public static IEnumerable<TResult> ProcessAll<TSource, TResult>(
            this IEnumerable<TSource>? source,
            Func<TSource, IEnumerable<TResult>> transform)
        {
            ConcurrentBag<TResult>? bag = default;

            return source.Process(
                result => bag!.Add(result),
                ForAll,
                () => bag = new ConcurrentBag<TResult>(),
                () => bag!.ToArray(),
                transform);
        }
    }
}