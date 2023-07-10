namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

/// <summary>
/// Provides extensions relating to <see cref="IEnumerable{T}"/>.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Provides for-like behavior in the form of a LINQ extension, enumerating the elements of <paramref name="items"/> and invoking
    /// <paramref name="action"/> for each element encountered.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
    /// <param name="items">The enumeration to be enumerated.</param>
    /// <param name="action">
    /// The action to be called for each element of the enumeration, with a zero-index value indicating the position of the element
    /// in the enueration.
    /// </param>
    /// <exception cref="ArgumentNullException">The <paramref name="action"/> is <see langword="null" />.</exception>
    public static void For<T>(this IEnumerable<T>? items, Action<int, T> action)
    {
        if (items is not null)
        {
            _ = IsNotNull(action, argumentName: nameof(action), message: EnumerableExtensionsActionRequired);

            PerformFor(items, action);
        }
    }

#if NET6_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void PerformFor<T>(this IEnumerable<T> items, Action<int, T> action)
    {
        T[] elements = items.ToArray();
        ref T source = ref MemoryMarshal.GetArrayDataReference(elements);

        for (int index = 0; index < elements.Length; index++)
        {
            T element = Unsafe.Add(ref source, index);

            action(index, element);
        }
    }
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void PerformFor<T>(this IEnumerable<T> items, Action<int, T> action)
    {
        int index = 0;

        foreach (T item in items)
        {
            action(index++, item);
        }
    }
#endif
}