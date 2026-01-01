namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax attribute extensions.
    /// </summary>
    public static partial class AttributeExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        internal static Snippet ToSnippet(this ImmutableArray<Attribute> attributes, Snippet.Options options)
        {
            if (attributes.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            return attributes
                .OrderBy(attribute => attribute.Name)
                .Select(attribute => Snippet.From(options, attribute))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}