namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax property extensions.
    /// </summary>
    public static partial class PropertyExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        internal static Snippet ToSnippet(this ImmutableArray<Property> properties, Snippet.Options options)
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

            return Snippet.Blank.Combine(options, content);
        }
    }
}