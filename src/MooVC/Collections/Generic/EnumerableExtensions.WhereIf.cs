namespace MooVC.Collections.Generic
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using static MooVC.Collections.Generic.Resources;
    using static MooVC.Ensure;

    public static partial class EnumerableExtensions
    {
        [return: NotNullIfNotNull("enumeration")]
        public static IEnumerable<T>? WhereIf<T>(this IEnumerable<T>? enumeration, bool isApplicable, Func<T, bool> predicate)
        {
            if (enumeration is { } && isApplicable)
            {
                ArgumentNotNull(predicate, nameof(predicate), EnumerableExtensionsWhereIfPredicateRequired);

                return enumeration.Where(predicate);
            }

            return enumeration;
        }

        [return: NotNullIfNotNull("enumeration")]
        public static IEnumerable<T>? WhereIf<T>(this IEnumerable<T>? enumeration, Func<bool> condition, Func<T, bool> predicate)
        {
            if (enumeration is { })
            {
                ArgumentNotNull(condition, nameof(condition), EnumerableExtensionsWhereIfConditionRequired);

                return enumeration.WhereIf(condition(), predicate);
            }

            return enumeration;
        }
    }
}