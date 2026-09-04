namespace MooVC.Syntax
{
    using System.Collections.Generic;
    using System.Linq;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.StringExtensions_Resources;

    /// <summary>
    /// Provides helpers for string analysis used by syntax generation.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Creates a <see cref="Snippet"/> from a collection of lines.
        /// </summary>
        /// <param name="lines">The lines from which to create the snippet.</param>
        /// <returns>The created snippet.</returns>
        public static Snippet ToSnippet(this IEnumerable<string> lines)
        {
            return lines.ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a <see cref="Snippet"/> from a collection of lines.
        /// </summary>
        /// <param name="lines">The lines from which to create the snippet.</param>
        /// <param name="options">The options for the snippet.</param>
        /// <returns>The created snippet.</returns>
        public static Snippet ToSnippet(this IEnumerable<string> lines, Snippet.Options options)
        {
            _ = Guard.Against.Null(lines, message: ToSnippetLinesRequired);
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired);

            return Snippet.From(options, lines.ToArray());
        }
    }
}