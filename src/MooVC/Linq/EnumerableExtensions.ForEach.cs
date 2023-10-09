namespace MooVC.Linq;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using static MooVC.Linq.EnumerableExtensions_Resources;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}" />.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Executes a synchronous action for each element in an enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of the elements of <paramref name="items" />.</typeparam>
    /// <param name="items">The sequence of elements to iterate over.</param>
    /// <param name="action">The action to execute for each element.</param>
    /// <exception cref="ArgumentNullException"><paramref name="action" /> is <see langword="null" />.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ForEach<T>(this IEnumerable<T>? items, Action<T> action)
    {
        if (items is not null)
        {
            _ = Guard.Against.Null(action, parameterName: nameof(action), message: ForActionRequired);

            items.For((_, item) => action(item));
        }
    }
}