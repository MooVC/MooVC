namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.CSharp.Generics.Constraints.ConstraintExtensions_Resources;

    public static partial class ConstraintExtensions
    {
        public static Snippet ToSnippet(this ImmutableArray<Constraint> constraints, Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Constraint)));

            if (constraints.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = options.NewLine.Combine(constraints, constraint => constraint.ToString());

            return Snippet.From(snippet);
        }
    }
}