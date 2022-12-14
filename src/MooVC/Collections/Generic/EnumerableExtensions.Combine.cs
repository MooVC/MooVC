﻿namespace MooVC.Collections.Generic;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides extensions relating to IEnumerable{T}.
/// </summary>
/// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
public static partial class EnumerableExtensions
{
    /// <summary>
    /// Appends <paramref name="instance"/> to the <paramref name="source"/> enumeration.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
    /// <param name="source">The enumeration to which the <paramref name="instance"/> is to be apended.</param>
    /// <param name="instance">The instance to be apended to the <paramref name="source"/> enumeration.</param>
    /// <returns>An enumerable containing the contents of <paramref name="source"/> with <paramref name="instance"/> appended. <br /><br />
    /// When <paramref name="source"/> is null, an enumeration containing the <paramref name="instance"/> element is returned.
    /// </returns>
    public static IEnumerable<T> Combine<T>(this IEnumerable<T>? source, T instance)
    {
        if (source is { })
        {
            return source.Append(instance);
        }

        return instance.AsEnumerable();
    }

    /// <summary>
    /// Appends the elements from the <paramref name="instances"/> enumeration to the <paramref name="source"/> enumeration.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the enumeration.</typeparam>
    /// <param name="source">The enumeration to which the <paramref name="instances"/> are to be apended.</param>
    /// <param name="instances">The enumeration to be apended to the <paramref name="source"/> enumeration.</param>
    /// <returns>An enumerable containing the contents of <paramref name="source"/> with the elements of <paramref name="instances"/> appended.
    /// <br /><br />When <paramref name="source"/> is null and <paramref name="instances"/> is null, an empty enumeration is returned. <br />
    /// When <paramref name="source"/> is null and <paramref name="instances"/> is set, the <paramref name="instances"/> enumeration reference is
    /// returned. <br /> When <paramref name="instances"/> is null and <paramref name="source"/> is set, the <paramref name="source"/> enumeration
    /// reference is returned.</returns>
    public static IEnumerable<T> Combine<T>(this IEnumerable<T>? source, IEnumerable<T>? instances)
    {
        if (source is null)
        {
            if (instances is null)
            {
                return Enumerable.Empty<T>();
            }

            return instances;
        }

        if (instances is null)
        {
            return source;
        }

        return source.Concat(instances);
    }
}