namespace MooVC.Collections.Generic;

using System.Collections.Generic;

public static partial class ObjectExtensions
{
    public static IEnumerable<T> AsEnumerable<T>(this T value)
    {
        yield return value;
    }
}