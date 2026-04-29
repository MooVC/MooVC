namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Directive"/> values.
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
            return directives.ToSnippet(Qualifier.Unqualified, options);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="directives">The directives.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Directive> directives, Qualifier @namespace, Snippet.Options options)
        {
            if (directives.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            bool IsInSameNamespace(Directive directive)
            {
                return directive.Alias.IsUnnamed && !directive.IsStatic && directive.Qualifier == @namespace;
            }

            return directives
                .Distinct()
                .Where(directive => !(directive.IsUndefined || IsInSameNamespace(directive)))
                .Select(directive => new
                {
                    Rendering = directive.Qualifier.ToString(),
                    Value = directive,
                })
                .OrderBy(directive => directive.Value.IsStatic)
                .ThenByDescending(directive => directive.Value.Alias.IsUnnamed)
                .ThenByDescending(directive => directive.Value.IsSystem)
                .ThenBy(directive => directive.Value.Alias)
                .ThenBy(directive => directive.Rendering)
                .Select(directive => directive.Value.ToSnippet(options))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}