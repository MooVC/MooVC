namespace MooVC.Linq;

using System;
using System.Linq;

public static partial class QueryableExtensions
{
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