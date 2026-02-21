namespace MooVC.Syntax.Elements
{
    using System.Collections.Immutable;

    /// <summary>
    /// Represents a syntax element snippet extensions.
    /// </summary>
    public static partial class SnippetExtensions
    {
        /// <summary>
        /// Performs the stack operation for the syntax element.
        /// </summary>
        /// <param name="snippets">The snippets.</param>
        /// <returns>The snippet.</returns>
        public static Snippet Stack(this ImmutableArray<Snippet> snippets)
        {
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
                stacked = snippets[index].Stack(stacked);
            }

            return stacked;
        }
    }
}