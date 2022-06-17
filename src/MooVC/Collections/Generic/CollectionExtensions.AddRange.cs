namespace MooVC.Collections.Generic;

using System.Collections.Generic;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class CollectionExtensions
{
    public static void AddRange<T>(this ICollection<T> target, IEnumerable<T>? items)
    {
        _ = ArgumentNotNull(
            target,
            nameof(target),
            CollectionExtensionsAddRangeTargetRequired);

        items.ForEach(item => target.Add(item));
    }
}