namespace MooVC.Syntax.Elements
{
    using System.Collections.Immutable;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        public interface IChain
        {
            ImmutableArray<string> Chain(string line);
        }
    }
}