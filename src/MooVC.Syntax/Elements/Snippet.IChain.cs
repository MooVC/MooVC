namespace MooVC.Syntax.Elements
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
            [SuppressMessage("Critical Code Smell", "S3218:Inner class members should not shadow outer class \"static\" or type members", Justification = "The method is used with that in the parent class.")]
            ImmutableArray<string> Chain(string line, Options options);
        }
    }
}