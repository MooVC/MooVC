namespace MooVC.Syntax.Elements
{
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using static MooVC.Syntax.Elements.SnippetExtensions_Resources;

    public static partial class SnippetExtensions
    {
        public static Snippet Stack(this ImmutableArray<Snippet> snippets, Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: OptionsRequired.Format(nameof(Snippet.Options), nameof(snippets)));

            if (snippets.IsDefaultOrEmpty)
            {
                return Snippet.Empty;
            }

            if (snippets.Length == 1)
            {
                return snippets[0];
            }

            Snippet stacked = snippets[0];

            for (int index = 1; index < snippets.Length; index++)
            {
                stacked = snippets[index].Stack(options, stacked);
            }

            return stacked;
        }
    }
}