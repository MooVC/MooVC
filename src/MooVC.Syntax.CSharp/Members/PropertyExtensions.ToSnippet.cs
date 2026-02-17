namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# member syntax property extensions.
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Property> properties, Property.Options options)
        {
            if (properties.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = properties
                .OrderByDescending(property => property.Extensibility == Extensibility.Static)
                .ThenByDescending(property => property.Scope)
                .ThenByDescending(property => property.Extensibility)
                .ThenBy(property => property.Name)
                .Select(property => property.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options.Snippets, content);
        }
    }
}