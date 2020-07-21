namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MooVC.Linq;

    public static partial class EnumerableExtensions
    {
        public static IEnumerable<TResult> Process<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, TResult> transform)
        {
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

        public static IEnumerable<TResult> Process<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, IEnumerable<TResult>> transform)
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
            if (source.SafeAny())
            {
                initialize();

                enumerator(
                    source,
                    item =>
                    {
                        IEnumerable<TResult> result = transform(item);

                        if (result is { })
                        {
                            result.ForEach(add);
                        }
                    });

                return snapshot();
            }

            return Enumerable.Empty<TResult>();
        }
    }
}