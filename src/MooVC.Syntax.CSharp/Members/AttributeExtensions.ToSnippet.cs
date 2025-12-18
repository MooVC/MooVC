namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class AttributeExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Attribute> attributes, Snippet.Options options)
        {
            if (attributes.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = attributes
                .OrderBy(attribute => attribute.Name)
                .Select(attribute => Snippet.From(options, attribute))
                .ToArray();

            string snippet = options.NewLine.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}