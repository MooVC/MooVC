namespace MooVC.Collections.Concurrent
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class ProducerConsumerCollectionExtensions
    {
        public static IEnumerable<T> Extract<T>(this IProducerConsumerCollection<T>? source, ulong? count = default)
        {
            if (source is null)
            {
                return Enumerable.Empty<T>();
            }

            var taken = new List<T>();
            ulong index = 0;

            count ??= ulong.MaxValue;

            while (index++ < count && source.TryTake(out T current))
            {
                taken.Add(current);
            }

            return taken.ToArray();
        }
    }
}