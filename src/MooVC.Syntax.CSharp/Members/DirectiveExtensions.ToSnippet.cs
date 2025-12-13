namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class DirectiveExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Directive> directives, Snippet.Options options)
        {
            string[] statements = directives
                .OrderBy(directive => directive.IsStatic)
                .ThenBy(directive => directive.IsSystem)
                .ThenBy(directive => directive.Alias.IsUnnamed)
                .Select(directive => directive.ToString())
                .ToArray();

            string snippet = options.NewLine.Combine(statements);

            return Snippet.From(options, snippet);
        }
    }
}