namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;

    public static partial class ParameterExtensions
    {
        private const string Separator = ", ";

        public static Snippet ToSnippet(this ImmutableArray<Parameter> parameters, Parameter.Options options)
        {
            if (parameters.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string snippet = Separator.Combine(parameters, parameter => parameter.ToString(options));

            return Snippet.From(snippet);
        }
    }
}