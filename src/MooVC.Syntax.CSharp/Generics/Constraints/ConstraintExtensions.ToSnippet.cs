namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class ConstraintExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Constraint> constraints, Snippet.Options options)
        {
            if (constraints.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var ordered = constraints
                .OrderBy(constraint => constraint)
                .ToImmutableArray();

            string snippet = options.NewLine.Combine(ordered, constraint => constraint.ToString());

            return Snippet.From(options, snippet);
        }
    }
}