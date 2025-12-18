namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class ConversionExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Conversion> conversions, Construct construct, Snippet.Options options)
        {
            if (conversions.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            var content = conversions
                .OrderByDescending(conversion => conversion.Scope)
                .ThenBy(conversion => conversion.Subject)
                .ThenBy(conversion => conversion.Direction)
                .Select(conversion => conversion.ToString(construct, options))
                .ToSnippet();

            string snippet = options.NewLine.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}