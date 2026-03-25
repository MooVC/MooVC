namespace MooVC.Syntax
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
            /// <summary>
            /// Gets the default chaining options.
            /// </summary>
            public static readonly ChainingOptions Default = ImmutableArray<IChain>.Empty;

            internal ChainingOptions(ImmutableArray<IChain> value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the current instance is the default options instance.
            /// </summary>
            public bool IsDefault => this == Default;

            /// <summary>
            /// Converts a chain array into a <see cref="ChainingOptions"/> instance.
            /// </summary>
            /// <param name="options">The chain options to include.</param>
            /// <returns>The created <see cref="ChainingOptions"/> instance.</returns>
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