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

            if (content.Length == 1)
            {
                return content[0];
            }

            Snippet stacked = content[0];

            for (int index = 1; index < content.Length; index++)
            {
                stacked = content[index].Stack(options, stacked);
            }

            return stacked;
        }
    }
}