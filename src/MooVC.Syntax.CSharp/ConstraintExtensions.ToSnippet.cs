namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Constraint"/> values.
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

        internal static Snippet ToSnippet(this ImmutableArray<Constraint> constraints, Name parameter, Snippet.Options options)
        {
            if (constraints.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] clauses = constraints
                .Select(constraint => constraint.ToString(parameter))
                .ToArray();

            return Snippet.From(options, clauses);
        }
    }
}