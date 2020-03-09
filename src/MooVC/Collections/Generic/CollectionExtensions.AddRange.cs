namespace MooVC.Collections.Generic
{
    using System.Collections.Generic;
    using static MooVC.Ensure;
    using static Resources;

    public static partial class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T>? items)
        {
            ArgumentNotNull(target, nameof(target), CollectionExtensionsGenericTargetRequired);

            items.ForEach(item => target.Add(item));
        }
    }
}