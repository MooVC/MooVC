namespace MooVC.Syntax
{
    using System.Collections.Immutable;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Defines options for the Snippet syntax element.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Defines a strategy for chaining snippet lines during formatting.
            /// </summary>
            public interface IChain
            {
                ImmutableArray<string> Chain(string line, Options options);
            }
        }
    }
}