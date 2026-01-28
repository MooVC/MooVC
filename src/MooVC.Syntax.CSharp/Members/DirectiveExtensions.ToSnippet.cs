namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# member syntax directive extensions.
    /// </summary>
    public static partial class DirectiveExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="directives">The directives.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Directive> directives, Snippet.Options options)
        {
            if (directives.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            return directives
                .Select(directive => new
                {
                    Rendering = directive.ToString(),
                    Value = directive,
                })
                .OrderBy(directive => directive.Value.IsStatic)
                .ThenByDescending(directive => directive.Value.Alias.IsUnnamed)
                .ThenByDescending(directive => directive.Value.IsSystem)
                .ThenBy(directive => directive.Value.Alias)
                .ThenBy(directive => directive.Value.Qualifier)
                .ThenBy(directive => directive.Rendering)
                .Select(directive => Snippet.From(options, directive.Rendering))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}