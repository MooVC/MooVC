namespace MooVC.Syntax
{
    using System.Collections.Immutable;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        public interface IChain
        {
            ImmutableArray<string> Chain(string line, Options options);
        }
    }
}