namespace MooVC.Syntax.CSharp.Generics
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# type syntax type extensions.
    /// </summary>
    public static partial class TypeExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# type syntax.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Type> types, Snippet.Options options)
        {
            if (types.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = types
                .OrderBy(type => type.Name)
                .Select(type => type.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}