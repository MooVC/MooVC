namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Comparison"/> values.
    /// </summary>
    public static partial class ComparisonExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="comparisons">The comparisons.</param>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Comparison> comparisons, Snippet.Options options, Type type)
        {
            if (comparisons.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = comparisons
                .OrderByDescending(comparison => comparison.Scope)
                .ThenBy(comparison => comparison.Operator)
                .Select(comparison => comparison.ToSnippet(options, type))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}