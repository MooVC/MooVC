namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# syntax element parameter extensions.
    /// </summary>
    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        /// <summary>
        /// Creates a code snippet representation of the c# syntax element.
        /// </summary>
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