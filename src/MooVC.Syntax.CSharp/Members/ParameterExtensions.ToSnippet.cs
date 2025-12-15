namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        internal static Snippet ToSnippet(this ImmutableArray<Parameter> parameters, Parameter.Options options)
        {
            if (parameters.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var ordered = parameters
                .OrderByDescending(parameter => parameter.Default.IsEmpty)
                .ThenBy(parameter => parameter.Modifier.IsParams)
                .ThenBy(parameter => parameter.Name)
                .ToImmutableArray();

            string snippet = Separator.Combine(ordered, parameter => parameter.ToString(options));

            return Snippet.From(snippet);
        }
    }
}