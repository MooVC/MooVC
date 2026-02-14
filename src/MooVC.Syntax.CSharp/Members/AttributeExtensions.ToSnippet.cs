namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# member syntax attribute extensions.
    /// </summary>
    public static partial class AttributeExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
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