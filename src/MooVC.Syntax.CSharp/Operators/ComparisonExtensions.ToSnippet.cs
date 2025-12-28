namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ComparisonExtensions
    {
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