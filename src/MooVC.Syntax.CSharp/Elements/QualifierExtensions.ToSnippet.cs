namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    public static partial class QualifierExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Qualifier> usings, Snippet.Options options)
        {
            if (usings.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            return usings
                .OrderBy(@using => @using)
                .Select(@using => @using.ToSnippet(options))
                .ToImmutableArray()
                .Stack(options);
        }
    }
}