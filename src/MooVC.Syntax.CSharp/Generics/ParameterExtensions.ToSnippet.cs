namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;

    /// <summary>
    /// Represents a C# generic syntax parameter extensions.
    /// </summary>
    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        /// <summary>
        /// Creates a snippet representation of the C# generic syntax.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="formatter">The formatter.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Parameter> parameters, Func<Parameter, string> formatter, Snippet.Options options)
        {
            if (parameters.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = Separator.Combine(parameters, formatter);

            return Snippet.From(options, snippet);
        }
    }
}