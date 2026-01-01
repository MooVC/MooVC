namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# operator syntax unary extensions.
    /// </summary>
    public static partial class UnaryExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# operator syntax.
        /// </summary>
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