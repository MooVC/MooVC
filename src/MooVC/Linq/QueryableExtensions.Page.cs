namespace MooVC.Linq
{
    using System.Linq;

    public static partial class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, Paging? paging)
        {
            return paging is null
                ? queryable
                : paging.Apply(queryable);
        }
    }
}