namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Provides for-like behavior in the form of a LINQ extension, enumerating the elements of <paramref name="items"/> and invoking
    /// <paramref name="action"/> for each element encountered.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
    /// <param name="items">The enumeration to be enumerated.</param>
    /// <param name="action">The action to be called for each element of the enumeration, with a zero-index value indicating the position of the
    /// element in the enueration.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="action"/> is null.</exception>
    public static void For<T>(this IEnumerable<T>? items, Action<int, T> action)
    {
        if (items is { })
        {
            _ = IsNotNull(action, message: EnumerableExtensionsActionRequired);

            ReadOnlySpan<T> elements = items.ToSpan();

            for (int index = 0; index < elements.Length; index++)
            {
                T element = elements[index];

                action(index, element);
            }
        }
    }
}