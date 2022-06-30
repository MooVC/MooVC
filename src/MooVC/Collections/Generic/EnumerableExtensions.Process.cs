namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
    public static IEnumerable<TResult> Process<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, TResult> transform)
        where TSource : notnull
    {
        if (source is { })
        {
            _ = ArgumentNotNull(transform, nameof(transform), EnumerableExtensionsProcessTransformRequired);

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

    public static IEnumerable<TResult> Process<TResult, TSource>(this IEnumerable<TSource>? source, Func<TSource, IEnumerable<TResult>> transform)
        where TSource : notnull
    {
        IDictionary<TSource, IEnumerable<TResult>>? transforms = default;

        return source.Process(
            (item, results) => transforms![item] = results,
            () => transforms!,
            ForEach,
            () => transforms = new Dictionary<TSource, IEnumerable<TResult>>(),
            transform);
    }

    private static IEnumerable<TResult> Process<TResult, TSource>(
        this IEnumerable<TSource>? source,
        Action<TSource, IEnumerable<TResult>> add,
        Func<IDictionary<TSource, IEnumerable<TResult>>> commit,
        Action<IEnumerable<TSource>?, Action<TSource>> enumerator,
        Action initialize,
        Func<TSource, IEnumerable<TResult>> transform)
    {
        if (source is { })
        {
            _ = ArgumentNotNull(transform, nameof(transform), EnumerableExtensionsProcessTransformRequired);

            source = source.Snapshot();

            initialize();
            enumerator(source, item => add(item, transform(item)));

            IDictionary<TSource, IEnumerable<TResult>> transforms = commit();

            return source
                .Select(original => transforms[original])
                .Where(transform => transform is { })
                .SelectMany(result => result)
                .ToArray();
        }

        return Enumerable.Empty<TResult>();
    }
}