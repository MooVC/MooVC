namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# operator syntax conversion extensions.
    /// </summary>
    public static partial class ConversionExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# operator syntax.
        /// </summary>
        /// <param name="conversions">The conversions.</param>
        /// <param name="options">The options.</param>
        /// <param name="type">The type.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Conversion> conversions, Snippet.Options options, Type type)
        {
            if (conversions.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = conversions
                .OrderByDescending(conversion => conversion.Scope)
                .ThenBy(conversion => conversion.Target)
                .ThenBy(conversion => conversion.Direction)
                .Select(conversion => conversion.ToSnippet(options, type))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}