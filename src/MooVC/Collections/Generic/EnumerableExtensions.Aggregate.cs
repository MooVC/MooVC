namespace MooVC.Collections.Generic;

using System.Collections.Generic;
using System.Linq;

public static partial class EnumerableExtensions
{
    public static IEnumerable<TResult> Aggregate<T, TResult>(
        this IEnumerable<T>? items,
        IDictionary<T, TResult>? source)
    {
        if (items is { } && source is { })
        {
            return items
                .Where(item => source.ContainsKey(item))
                .Select(item => source[item])
                .ToArray();
        }

        return Enumerable.Empty<TResult>();
    }
}