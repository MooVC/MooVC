namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Attribute"/> values.
    /// </summary>
    public static partial class AttributeExtensions
    {
        private const string Separator = ", ";

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Attribute> attributes, Attribute.Options options)
        {
            if (attributes.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            IEnumerable<Snippet> renderings = attributes
                .OrderBy(attribute => attribute.Name)
                .Select(attribute => attribute.ToSnippet(options));

            if (options.Format.IsSeparate)
            {
                return renderings
                    .Select(attribute => Snippet.From($"[{attribute[0]}]"))
                    .ToImmutableArray()
                    .Stack(options);
            }

            string content = string.Join(Separator, renderings.Select(attribute => attribute[0]));

            return Snippet.From(options, $"[{content}]");
        }
    }
}