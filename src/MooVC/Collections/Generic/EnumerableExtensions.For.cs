namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
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