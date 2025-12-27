namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class ConstraintExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Constraint> constraints, Snippet.Options options)
        {
            if (constraints.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] clauses = constraints
                .Select(constraint => constraint.ToString())
                .ToArray();

            return Snippet.From(options, clauses);
        }
    }
}