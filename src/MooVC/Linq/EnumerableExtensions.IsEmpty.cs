namespace MooVC.Linq
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    public static partial class EnumerableExtensions
    {
        public static bool IsEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source)
        {
            return source is null || !source.Any();
        }
    }
}