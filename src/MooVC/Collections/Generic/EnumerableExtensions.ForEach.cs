﻿namespace MooVC.Collections.Generic;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static MooVC.Collections.Generic.Resources;
using static MooVC.Ensure;

public static partial class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T>? items, Action<T> action)
    {
        if (items is { })
        {
            _ = IsNotNull(action, message: EnumerableExtensionsActionRequired);

            ReadOnlySpan<T> elements = items.ToSpan();

            foreach (T element in elements)
            {
                action(element);
            }
        }
    }
}