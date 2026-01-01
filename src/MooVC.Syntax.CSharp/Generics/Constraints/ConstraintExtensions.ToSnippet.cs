namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# generic syntax constraint extensions.
    /// </summary>
    public static partial class ConstraintExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# generic syntax.
        /// </summary>
        /// <param name="constraints">The constraints.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
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