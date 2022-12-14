namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Executes a synchronous action for each element in an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="items"/>.</typeparam>
    /// <param name="items">The sequence of elements to iterate over.</param>
    /// <param name="action">The action to execute for each element.</param>
    /// <exception cref="ArgumentNullException"><paramref name="action"/> is null.</exception>
    public static void ForEach<T>(this IEnumerable<T>? items, Action<T> action)
    {
        if (items is { })
        {
            _ = IsNotNull(action, message: EnumerableExtensionsActionRequired);

            items.For((_, item) => action(item));
        }
    }
}