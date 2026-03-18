namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;
    using MooVC.Syntax.Formatting;

    /// <summary>
    /// Represents a C# generic syntax generic extensions.
    /// </summary>
    public static partial class GenericExtensions
    {
        private const string Separator = ", ";

        /// <summary>
        /// Creates a snippet representation of the C# generic syntax.
        /// </summary>
        /// <param name="generics">The generics.</param>
        /// <param name="formatter">The formatter.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Generic> generics, Func<Generic, string> formatter, Snippet.Options options)
        {
            if (generics.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = Separator.Combine(generics, formatter);

            return Snippet.From(options, snippet);
        }
    }
}