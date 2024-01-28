namespace MooVC;
/// <summary>
/// Provides extensions relating to <see cref="Array" />.
/// </summary>
public static partial class ArrayExtensions
{
    /// <summary>
    /// Extends an array by appending the elements of another array.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the arrays.</typeparam>
    /// <param name="source">The array to extend.</param>
    /// <param name="others">The array containing the elements to append to the source array.</param>
    /// <returns>An array containing the original elements of the source array, with the elements of the other array appended at the end.</returns>
    public static T[] Append<T>(this T[]? source, params T[]? others)
    {
        if (source is null)
        {
            return others.ToCopyOrEmpty();
        }

        if (others is null)
        {
            return source.ToCopyOrEmpty();
        }

        var destination = new T[source.Length + others.Length];

        Array.Copy(source, 0, destination, 0, source.Length);
        Array.Copy(others, 0, destination, source.Length, others.Length);

        return destination;
    }
}