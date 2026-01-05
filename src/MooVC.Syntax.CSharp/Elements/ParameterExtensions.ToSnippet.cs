namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# syntax element parameter extensions.
    /// </summary>
    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        /// <summary>
        /// Creates a snippet representation of the C# syntax element.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Parameter> parameters, Parameter.Options options)
        {
            if (parameters.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var ordered = parameters
                .OrderBy(parameter => parameter.Modifier.IsParams)
                .ThenByDescending(parameter => parameter.Default.IsEmpty)
                .ThenBy(parameter => parameter.Name)
                .ToImmutableArray();

            string snippet = Separator.Combine(ordered, parameter => parameter.ToSnippet(options));

            return Snippet.From(snippet);
        }
    }
}