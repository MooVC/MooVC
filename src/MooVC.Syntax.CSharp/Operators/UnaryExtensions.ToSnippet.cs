namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class UnaryExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Unary> unaries, Construct construct, Snippet.Options options)
        {
            if (unaries.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var content = unaries
                .OrderByDescending(unary => unary.Scope)
                .ThenBy(unary => unary.Operator)
                .Select(unary => unary.ToString(construct, options))
                .ToSnippet();

            string snippet = options.BlankSpace.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}