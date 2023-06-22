namespace MooVC.Linq;

using System.Diagnostics.CodeAnalysis;
using System.Linq;

/// <summary>
/// Provides extensions relating to <see cref="IQueryable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the sequence.</typeparam>
public static partial class QueryableExtensions
{
    /// <summary>
    /// Applies paging to an IQueryable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable sequence.</typeparam>
    /// <param name="queryable">The IQueryable sequence to apply paging to.</param>
    /// <param name="paging">The paging parameters to apply to the IQueryable sequence.</param>
    /// <returns>
    /// The original IQueryable sequence with paging applied, or null if the original IQueryable was null.
    /// </returns>
 #if NET6_0_OR_GREATER
    [return: NotNullIfNotNull(nameof(queryable))]
#endif
    public static IQueryable<T>? Page<T>(this IQueryable<T>? queryable, Paging? paging)
    {
        if (queryable is { } && paging is { })
        {
            return paging.Apply(queryable);
        }

        return queryable;
    }
}