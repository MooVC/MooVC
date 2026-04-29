namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Unary"/> values.
    /// </summary>
    public static partial class UnaryExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="unaries">The unaries.</param>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Unary> unaries, Snippet.Options options, Type type)
        {
            if (unaries.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = unaries
                .OrderByDescending(unary => unary.Scope)
                .ThenBy(unary => unary.Operator)
                .Select(unary => unary.ToSnippet(options, type))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}