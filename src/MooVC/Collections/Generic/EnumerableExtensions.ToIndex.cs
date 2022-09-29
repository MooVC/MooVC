namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
    public static IDictionary<TSubject, TValue> ToIndex<TSubject, TValue>(this IEnumerable<TSubject>? source, Func<TSubject, TValue> selector)
        where TSubject : notnull
    {
        return source.ToIndex(selector, value => value);
    }

    public static IDictionary<TSubject, TTransform> ToIndex<TSubject, TTransform, TValue>(
        this IEnumerable<TSubject>? source,
        Func<TSubject, TValue> selector,
        Func<TValue, TTransform> transform)
        where TSubject : notnull
    {
        selector = IsNotNull(selector, message: EnumerableExtensionsToIndexSelectorRequired);
        transform = IsNotNull(transform, message: EnumerableExtensionsToIndexTransformRequired);

        if (source is null)
        {
            return new Dictionary<TSubject, TTransform>();
        }

        return source
            .Select(key => new
            {
                Key = key,
                Value = selector(key),
            })
            .ToDictionary(key => key.Key, key => transform(key.Value));
    }
}