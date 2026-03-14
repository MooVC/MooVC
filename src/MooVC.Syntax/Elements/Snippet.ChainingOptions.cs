namespace MooVC.Syntax.Elements
{
    using System.Collections.Immutable;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Represents a syntax element boundary options.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [Monify(Type = typeof(ImmutableArray<IChain>))]
        public sealed partial class ChainingOptions
        {
            public static readonly ChainingOptions Default = ImmutableArray<IChain>.Empty;

            internal ChainingOptions(ImmutableArray<IChain> value)
            {
                _value = value;
            }

            public bool IsDefault => this == Default;
        }
    }
}