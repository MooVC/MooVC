namespace MooVC.Linq;

using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Linq.IEnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class IEnumerableExtensions
{
    /// <summary>
    /// Creates a dictionary from an enumerable source by applying a selector function to each element of the source.
    /// The selector function specifies the key for each element of the resulting dictionary.
    /// </summary>
    /// <typeparam name="TSubject">The type of elements in the source enumerable.</typeparam>
    /// <typeparam name="TValue">The type of value that the selector function returns.</typeparam>
    /// <param name="source">The source enumerable.</param>
    /// <param name="selector">A function that returns the value for each key in the dictionary.</param>
    /// <returns>A dictionary that contains the keys and values returned by the selector function.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDictionary<TSubject, TValue> ToIndex<TSubject, TValue>(this IEnumerable<TSubject>? source, Func<TSubject, TValue> selector)
        where TSubject : notnull
    {
        return source.ToIndex(selector, value => value);
    }

    /// <summary>
    /// Maps a dictionary to the specified selector and transform functions, returning the resulting dictionary.
    /// </summary>
    /// <typeparam name="TSubject">The type of the elements in the input sequence.</typeparam>
    /// <typeparam name="TTransform">The type of the value returned by the transform function.</typeparam>
    /// <typeparam name="TValue">The type of the value returned by the selector function.</typeparam>
    /// <param name="source">The input sequence.</param>
    /// <param name="selector">A function that maps each element of the input sequence to a value.</param>
    /// <param name="transform">A function that maps the result of the selector function to a value of the resulting dictionary.</param>
    /// <returns>A dictionary containing the results of applying the selector and transform functions to the input sequence.</returns>
    public static IDictionary<TSubject, TTransform> ToIndex<TSubject, TTransform, TValue>(
        this IEnumerable<TSubject>? source,
        Func<TSubject, TValue> selector,
        Func<TValue, TTransform> transform)
        where TSubject : notnull
    {
        selector = Guard.Against.Null(selector, message: ToIndexSelectorRequired);
        transform = Guard.Against.Null(transform, message: ToIndexTransformRequired);

        if (source is null)
        {
            return new Dictionary<TSubject, TTransform>();
        }

        return source
            .Select(key => new
            {
                Key = key,
                Value = selector(key),
            })
            .ToDictionary(key => key.Key, key => transform(key.Value));
    }
}