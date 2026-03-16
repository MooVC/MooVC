namespace MooVC.Syntax.Elements
{
    using System.Collections.Immutable;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;

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

            public static implicit operator ChainingOptions(IChain[] options)
            {
                Guard.Against.Conversion<IChain[], ChainingOptions>(options);

                if (options.Length == 0)
                {
                    return Default;
                }

                return options.ToImmutableArray();
            }
        }
    }
}