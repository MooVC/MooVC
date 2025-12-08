namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Immutable;

    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        public static Snippet ToSnippet(this ImmutableArray<Parameter> parameters, Func<Parameter, string> formatter)
        {
            if (parameters.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = Separator.Combine(parameters, formatter);

            return Snippet.From(snippet);
        }
    }
}