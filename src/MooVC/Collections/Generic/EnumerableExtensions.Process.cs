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
        {
            if (source is { })
            {
                ArgumentNotNull(transform, nameof(transform), EnumerableExtensionsProcessTransformRequired);

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
        {
            IList<TResult>? list = default;

            return source.Process(
                result => list!.Add(result),
                ForEach,
                () => list = new List<TResult>(),
                () => list!.ToArray(),
                transform);
        }

        private static IEnumerable<TResult> Process<TResult, TSource>(
            this IEnumerable<TSource>? source,
            Action<TResult> add,
            Action<IEnumerable<TSource>?, Action<TSource>> enumerator,
            Action initialize,
            Func<IEnumerable<TResult>> snapshot,
            Func<TSource, IEnumerable<TResult>> transform)
        {
            if (source is { })
            {
                ArgumentNotNull(transform, nameof(transform), EnumerableExtensionsProcessTransformRequired);

                initialize();

                enumerator(source, item => transform(item).ForEach(add));

                return snapshot();
            }

            return Enumerable.Empty<TResult>();
        }
    }
}