namespace MooVC;

public static partial class ArrayExtensions
{
    public static T[] Prepend<T>(this T[]? source, T other)
    {
        return new[] { other }.Extend(source);
    }
}