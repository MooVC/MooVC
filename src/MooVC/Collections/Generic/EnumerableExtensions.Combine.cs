namespace MooVC.Collections.Generic;

using System.Collections.Generic;
using System.Linq;

public static partial class EnumerableExtensions
{
    public static IEnumerable<T> Combine<T>(this IEnumerable<T>? source, T instance)
    {
        if (source is { })
        {
            return source.Append(instance);
        }

        return new[] { instance };
    }

    public static IEnumerable<T> Combine<T>(this IEnumerable<T>? source, IEnumerable<T>? instances)
    {
        instances ??= Enumerable.Empty<T>();

        if (source is { })
        {
            return source.Concat(instances);
        }

        return instances;
    }
}