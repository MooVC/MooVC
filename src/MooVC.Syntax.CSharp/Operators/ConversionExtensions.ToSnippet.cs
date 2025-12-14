namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;
    using MooVC.Syntax.CSharp.Operators;

    public static partial class ConversionExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Conversion> conversions, Construct construct, Snippet.Options options)
        {
            if (conversions.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = conversions
                .OrderBy(conversion => conversion)
                .Select(conversion => conversion.ToString(construct, options))
                .ToArray();

            string snippet = options.BlankSpace.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}