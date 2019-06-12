namespace MooVC.Collections.Generic
{
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        public static T[] Snapshot<T>(this IEnumerable<T> enumerable)
        {
            return enumerable?.ToArray() ?? new T[0];
        }
    }
}