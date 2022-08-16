namespace MooVC.Collections.Generic;

public static partial class ObjectExtensions
{
    public static T[] AsArray<T>(this T value)
    {
        return new[] { value };
    }
}