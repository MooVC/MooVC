namespace MooVC;

using System.Linq;
using MooVC.Collections.Generic;

public static partial class ArrayExtensions
{
    public static T[] Extend<T>(this T[]? source, T[]? other)
    {
        return source.Combine(other).ToArray();
    }
}