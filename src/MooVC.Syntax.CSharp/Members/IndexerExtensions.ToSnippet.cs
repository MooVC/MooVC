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
                .OrderByDescending(@event => @event.Scope)
                .ThenByDescending(@event => @event.Extensibility)
                .ThenBy(indexer => indexer.Parameter.Name)
                .ThenBy(indexer => indexer.Result.Type)
                .Select(indexer => indexer.ToString(options))
                .ToArray();

            return options.BlankSpace.Combine(options, content);
        }
    }
}