namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class PropertyExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Property> properties, Snippet.Options options)
        {
            if (properties.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = properties
                .OrderByDescending(property => property.Extensibility == Extensibility.Static)
                .ThenByDescending(property => property.Scope)
                .ThenByDescending(property => property.Extensibility)
                .ThenBy(property => property.Name)
                .Select(property => property.ToString())
                .ToArray();

            string snippet = options.NewLine.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}