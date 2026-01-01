namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a c# member syntax indexer extensions.
    /// </summary>
    public static partial class IndexerExtensions
    {
        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        internal static Snippet ToSnippet(this ImmutableArray<Indexer> indexers, Snippet.Options options)
        {
            if (indexers.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            Snippet[] content = indexers
                .OrderByDescending(@event => @event.Scope)
                .ThenByDescending(@event => @event.Extensibility)
                .ThenBy(indexer => indexer.Parameter.Name)
                .ThenBy(indexer => indexer.Result.Type)
                .Select(indexer => indexer.ToSnippet(options))
                .ToArray();

            return Snippet.Blank.Combine(options, content);
        }
    }
}