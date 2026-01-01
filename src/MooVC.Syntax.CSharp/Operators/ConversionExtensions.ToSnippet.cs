namespace MooVC.Syntax.CSharp.Operators
{
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# operator syntax conversion extensions.
    /// </summary>
    public static partial class ConversionExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# operator syntax.
        /// </summary>
        internal static Snippet ToSnippet(this ImmutableArray<Conversion> conversions, Snippet.Options options, Type type)
        {
            if (conversions.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = conversions
                .OrderByDescending(conversion => conversion.Scope)
                .ThenBy(conversion => conversion.Subject)
                .ThenBy(conversion => conversion.Direction)
                .Select(conversion => conversion.ToSnippet(options, type))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}