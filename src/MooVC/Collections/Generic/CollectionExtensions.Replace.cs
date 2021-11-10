namespace MooVC.Collections.Generic
{
    using System.Collections.Generic;
    using static MooVC.Ensure;
    using static Resources;

    public static partial class CollectionExtensions
    {
        public static void Replace<T>(this ICollection<T> target, IEnumerable<T>? replacements)
        {
            _ = ArgumentNotNull(
                target,
                nameof(target),
                CollectionExtensionsReplaceTargetRequired);

            target.Clear();

            if (replacements is { })
            {
                target.AddRange(replacements);
            }
        }
    }
}