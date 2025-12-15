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
                .Select(directive => new
                {
                    Rendering = directive.ToString(),
                    Value = directive,
                })
                .OrderBy(directive => directive.Value.IsStatic)
                .ThenBy(directive => directive.Value.IsSystem)
                .ThenBy(directive => directive.Value.Alias.IsUnnamed)
                .ThenBy(directive => directive.Value.Alias)
                .ThenBy(directive => directive.Value.Qualifier)
                .ThenBy(directive => directive.Rendering)
                .Select(directive => directive.Rendering)
                .ToArray();

            string snippet = options.NewLine.Combine(statements);

            return Snippet.From(options, snippet);
        }
    }
}