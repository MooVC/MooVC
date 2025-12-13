namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Immutable;

    public static partial class ConstraintExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Constraint> constraints, Snippet.Options options)
        {
            if (constraints.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = options.NewLine.Combine(constraints, constraint => constraint.ToString());

            return Snippet.From(options, snippet);
        }
    }
}