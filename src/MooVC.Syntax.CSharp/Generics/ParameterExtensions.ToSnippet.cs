namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        internal static Snippet ToSnippet(this ImmutableArray<Parameter> parameters, Func<Parameter, string> formatter, Snippet.Options options)
        {
            if (parameters.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var ordered = parameters
                .OrderBy(parameter => parameter)
                .ToImmutableArray();

            string snippet = Separator.Combine(ordered, formatter);

            return Snippet.From(options, snippet);
        }
    }
}