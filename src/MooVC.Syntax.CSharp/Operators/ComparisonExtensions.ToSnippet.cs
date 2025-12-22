namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ComparisonExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Comparison> comparisons, Construct construct, Snippet.Options options)
        {
            if (comparisons.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var content = comparisons
                .OrderByDescending(comparison => comparison.Scope)
                .ThenBy(comparison => comparison.Operator)
                .Select(comparison => comparison.ToSnippet(construct, options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}