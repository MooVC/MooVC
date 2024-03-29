﻿namespace MooVC.Collections.Generic;

using System.Runtime.CompilerServices;

/// <summary>
/// Provides extensions relating to <see cref="IDictionary{TKey, TValue}" />.
/// </summary>
/// <typeparam name="TKey">Specifies the type of keys in the dictionary.</typeparam>
/// <typeparam name="TValue">Specifies the type of values in the dictionary.</typeparam>
public static partial class IDictionaryExtensions
{
    /// <summary>
    /// Populates a new dictionary instance with the contents of the <paramref name="source" /> dictionary.
    /// </summary>
    /// <typeparam name="TKey">Specifies the type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">Specifies the type of values in the dictionary.</typeparam>
    /// <param name="source">The dictionary from which the contents are to be copied.</param>
    /// <returns>A new dictionary instance that contains the contents of the <paramref name="source" /> dictionary.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IDictionary<TKey, TValue> ToNewOrCopy<TKey, TValue>(this IDictionary<TKey, TValue>? source)
        where TKey : notnull
    {
        if (source is null)
        {
            return new Dictionary<TKey, TValue>();
        }

        return new Dictionary<TKey, TValue>(source);
    }
}