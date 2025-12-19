namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class DirectiveExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Directive> directives, Snippet.Options options)
        {
            Snippet[] statements = directives
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
                .Select(directive => Snippet.From(options, directive.Rendering))
                .ToArray();

            return Snippet.Blank.Combine(options, statements);
        }
    }
}