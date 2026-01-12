namespace MooVC.Syntax.Formatting
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a formatting helper string extensions.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the formatting helper.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this string value)
        {
            var snippet = ImmutableArray.Create(value);

            return new Snippet(snippet);
        }

        /// <summary>
        /// Creates a snippet representation of the formatting helper.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this IEnumerable<string> values)
        {
            var lines = values
                .Where(value => !string.IsNullOrEmpty(value))
                .ToImmutableArray();

            return new Snippet(lines);
        }
    }
}