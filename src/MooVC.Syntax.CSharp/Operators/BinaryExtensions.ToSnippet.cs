namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class BinaryExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Binary> binaries, Construct construct, Snippet.Options options)
        {
            if (binaries.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = binaries
                .OrderByDescending(binary => binary.Scope)
                .ThenBy(binary => binary.Operator)
                .Select(binary => binary.ToSnippet(construct, options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}