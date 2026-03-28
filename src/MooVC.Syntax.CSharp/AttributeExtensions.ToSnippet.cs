namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;

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
        internal static Snippet ToSnippet(this ImmutableArray<Attribute> attributes, Type.Options options)
        {
            if (attributes.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            return attributes
                .OrderBy(attribute => attribute.Name)
                .Select(attribute => attribute.ToSnippet(options))
                .Select(attribute => Snippet.From($"[{attribute[0]}]"))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}