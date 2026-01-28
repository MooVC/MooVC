#if NET6_0_OR_GREATER
namespace MooVC.Linq;

using System.Diagnostics.CodeAnalysis;
using MooVC.Paging;

/// <summary>
/// Provides extensions relating to <see cref="IQueryable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the sequence.</typeparam>
public static partial class IQueryableExtensions
{
    /// <summary>
    /// Applies paging to an IQueryable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the IQueryable sequence.</typeparam>
    /// <param name="queryable">The IQueryable sequence to apply paging to.</param>
    /// <param name="directive">The paging parameters to apply to the IQueryable sequence.</param>
    /// <returns>
    /// The original IQueryable sequence with paging applied, or null if the original IQueryable was null.
    /// </returns>
    [return: NotNullIfNotNull(nameof(queryable))]
    public static IQueryable<T>? Page<T>(this IQueryable<T>? queryable, Directive directive)
    {
        if (queryable is null || directive.IsAll)
        {
            return queryable;
        }

        return queryable
            .Skip(directive.Skip)
            .Take(directive.Take);
    }
}
#endif