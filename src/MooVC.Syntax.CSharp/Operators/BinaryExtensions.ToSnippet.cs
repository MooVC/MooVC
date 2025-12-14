namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Concepts;

    public static partial class BinaryExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Binary> binaries, Construct construct, Snippet.Options options)
        {
            if (binaries.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = binaries
                .OrderBy(binary => binary)
                .Select(binary => binary.ToString(construct, options))
                .ToArray();

            string snippet = options.BlankSpace.Combine(content);

            return Snippet.From(options, snippet);
        }
    }
}