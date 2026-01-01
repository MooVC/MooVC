namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# generic syntax constraint extensions.
    /// </summary>
    public static partial class ConstraintExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# generic syntax.
        /// </summary>
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