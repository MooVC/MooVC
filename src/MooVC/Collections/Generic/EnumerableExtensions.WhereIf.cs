namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> enumeration, bool isApplicable, Func<T, bool> predicate)
        {
            return isApplicable
                ? enumeration.Where(predicate)
                : enumeration;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> enumeration, Func<bool> condition, Func<T, bool> predicate)
        {
            return enumeration.WhereIf(condition(), predicate);
        }
    }
}