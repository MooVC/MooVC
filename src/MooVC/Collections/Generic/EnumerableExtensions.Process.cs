namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> Process<TResult, TSource>(
            this IEnumerable<TSource>? source,
            Func<TSource, TResult> transform)
            where TSource : notnull
        {
            if (source is { })
            {
                _ = ArgumentNotNull(
                    transform,
                    nameof(transform),
                    EnumerableExtensionsProcessTransformRequired);

                return source.Process(
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

        public static IEnumerable<TResult> Process<TResult, TSource>(
            this IEnumerable<TSource>? source,
            Func<TSource, IEnumerable<TResult>> transform)
            where TSource : notnull
        {
            IDictionary<TSource, IEnumerable<TResult>>? list = default;

            return source.Process(
                (item, results) => list![item] = results,
                ForEach,
                () => list = new Dictionary<TSource, IEnumerable<TResult>>(),
                () => list!.Values,
                transform);
        }

        private static IEnumerable<TResult> Process<TResult, TSource>(
            this IEnumerable<TSource>? source,
            Action<TSource, IEnumerable<TResult>> add,
            Action<IEnumerable<TSource>?, Action<TSource>> enumerator,
            Action initialize,
            Func<IEnumerable<IEnumerable<TResult>>> snapshot,
            Func<TSource, IEnumerable<TResult>> transform)
        {
            if (source is { })
            {
                _ = ArgumentNotNull(
                    transform,
                    nameof(transform),
                    EnumerableExtensionsProcessTransformRequired);

                initialize();

                enumerator(source, item => add(item, transform(item)));

                return snapshot()
                    .Where(result => result is { })
                    .SelectMany(result => result)
                    .ToArray();
            }

            return Enumerable.Empty<TResult>();
        }
    }
}