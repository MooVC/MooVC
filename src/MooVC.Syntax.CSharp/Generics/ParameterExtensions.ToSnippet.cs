namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;

    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

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