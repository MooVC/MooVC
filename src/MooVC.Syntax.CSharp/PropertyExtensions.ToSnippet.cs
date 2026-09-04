namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    /// <summary>
    /// Provides snippet conversion helpers for <see cref="Property"/> values.
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
                .OrderByDescending(property => property.Extensibility == Modifiers.Static)
                .ThenByDescending(property => property.Scope)
                .ThenByDescending(property => property.Extensibility)
                .ThenBy(property => property.Name)
                .Select(property => property.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}