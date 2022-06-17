namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Linq;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
    public static T[] Snapshot<T>(
        this IEnumerable<T>? enumerable,
        Func<T, bool>? predicate = default)
    {
        if (enumerable is { })
        {
            return enumerable
                .WhereIf(predicate is { }, predicate!)
                .ToArray();
        }

        return Array.Empty<T>();
    }

    public static T[] Snapshot<T, TKey>(
        this IEnumerable<T>? enumerable,
        Func<T, TKey> order,
        Func<T, bool>? predicate = default)
    {
        _ = ArgumentNotNull(
            order,
            nameof(order),
            EnumerableExtensionsSnapshotOrderRequired);

        return enumerable
            .Snapshot(predicate: predicate)
            .OrderBy(order)
            .ToArray();
    }
}