namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Linq;

    public static partial class IndexerExtensions
    {
        internal static Snippet ToSnippet(this ImmutableArray<Indexer> indexers, Snippet.Options options)
        {
            if (indexers.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            string[] content = indexers
                .OrderBy(indexer => indexer)
                .Select(indexer => indexer.ToString(options))
                .ToArray();

            return options.BlankSpace.Combine(options, content);
        }
    }
}