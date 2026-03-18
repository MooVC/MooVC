namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;
    using MooVC.Syntax.Formatting;

    /// <summary>
    /// Represents a C# generic syntax argument extensions.
    /// </summary>
    public static partial class ArgumentExtensions
    {
        private const string Separator = ", ";

        /// <summary>
        /// Creates a snippet representation of the C# generic syntax.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="formatter">The formatter.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Argument> arguments, Func<Argument, string> formatter, Snippet.Options options)
        {
            if (arguments.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = Separator.Combine(arguments, formatter);

            return Snippet.From(options, snippet);
        }
    }
}