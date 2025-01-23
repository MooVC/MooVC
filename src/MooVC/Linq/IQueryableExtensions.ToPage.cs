#if NET6_0_OR_GREATER
namespace MooVC.Linq;

using MooVC.Paging;

/// <summary>
/// Provides extensions relating to <see cref="IQueryable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the sequence.</typeparam>
public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Applies paging to an IQueryable sequence to produce a paged result.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable sequence.</typeparam>
    /// <param name="queryable">The IQueryable sequence to which paging is to be applied.</param>
    /// <param name="directive">The paging parameters to apply to the IQueryable sequence.</param>
    /// <param name="includeTotal">
    /// A flag indicating whether or not the <see cref="Queryable.LongCount{TSource}(IQueryable{TSource})"/> should be applied to the <paramref name="queryable"/>.
    /// </param>
    /// <returns>
    /// A paged result that contains the elements of the IQueryable sequence, with paging applied and metadata about the total number of
    /// elements and the applied paging parameters.
    /// </returns>
    public static Page<T> ToPage<T>(this IQueryable<T>? queryable, Directive directive, bool includeTotal = true)
    {
        ulong? total = default;
        T[] values = [];

        if (queryable is not null)
        {
            if (includeTotal)
            {
                total = (ulong)queryable.LongCount();
            }

            queryable = queryable.Page(directive);
            values = [.. queryable];
        }

        return new Page<T>(directive, values, total: total);
    }
}
#endif