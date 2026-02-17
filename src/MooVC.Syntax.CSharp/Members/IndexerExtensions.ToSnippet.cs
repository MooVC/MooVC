namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using MooVC.Syntax.Elements;

    /// <summary>
    /// Represents a C# member syntax indexer extensions.
    /// </summary>
    public static partial class IndexerExtensions
    {
        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="indexers">The indexers.</param>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        internal static Snippet ToSnippet(this ImmutableArray<Indexer> indexers, Indexer.Options options)
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

            return Snippet.Blank.Combine(options.Snippets, content);
        }
    }
}