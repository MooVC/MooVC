namespace MooVC.Syntax.CSharp
{
    using System.Collections.Immutable;

    internal static partial class SnippetExtensions
    {
        public static Snippet Stack(this ImmutableArray<Snippet> snippets, Snippet.Options options)
        {
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