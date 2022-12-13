namespace MooVC.Linq;

using System;
using System.Linq;

public static partial class QueryableExtensions
{
    /// <summary>
    /// Applies paging to an IQueryable sequence to produce a paged result.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable sequence.</typeparam>
    /// <param name="queryable">The IQueryable sequence to which paging is to be applied.</param>
    /// <param name="paging">The paging parameters to apply to the IQueryable sequence.</param>
    /// <returns>
    /// A paged result that contains the elements of the IQueryable sequence, with paging applied and metadata about the total number of
    /// elements and the applied paging parameters.</returns>
    public static PagedResult<T> ToResult<T>(this IQueryable<T>? queryable, Paging? paging)
    {
        ulong total = 0;
        T[] values = Array.Empty<T>();

        paging ??= Paging.None;

        if (queryable is { })
        {
            total = (ulong)queryable.LongCount();
            queryable = queryable.Page(paging);
            values = queryable.ToArray();
        }

        return new PagedResult<T>(paging, total, values);
    }
}