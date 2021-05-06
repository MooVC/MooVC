namespace MooVC.Linq
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public static partial class QueryableExtensions
    {
        [return: NotNullIfNotNull("queryable")]
        public static IQueryable<T>? Page<T>(this IQueryable<T>? queryable, Paging? paging)
        {
            if (queryable is { } && paging is { })
            {
                return paging.Apply(queryable);
            }

            return queryable;
        }
    }
}