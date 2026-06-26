namespace MooVC.Syntax
{
    using System.Collections.Immutable;
    using System.Diagnostics;
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
        /// Defines options for the Snippet syntax element.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Represents a syntax element boundary options.
            /// </summary>
            [AutoInitializeWith(nameof(Default))]
            [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
            [Monify(Type = typeof(ImmutableArray<IChain>))]
            public sealed partial class Strategies
            {
                /// <summary>
                /// Gets the default chaining options.
                /// </summary>
                public static readonly Strategies Default = ImmutableArray<IChain>.Empty;

                internal Strategies(ImmutableArray<IChain> value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the current instance is the default options instance.
                /// </summary>
                public bool IsDefault => this == Default;

                /// <summary>
                /// Converts a chain array into a <see cref="Strategies"/> instance.
                /// </summary>
                /// <param name="options">The chain options to include.</param>
                /// <returns>The created <see cref="Strategies"/> instance.</returns>
                public static implicit operator Strategies(IChain[] options)
                {
                    Guard.Against.Conversion<IChain[], Strategies>(options);

                    if (options.Length == 0)
                    {
                        return Default;
                    }

                    return options.ToImmutableArray();
                }

                private string GetDebuggerDisplay()
                {
                    return $"{nameof(Strategies)} {{ {nameof(IsDefault)} = `{DebuggerDisplayFormatter.Format(IsDefault)}`, Length: {_value.Length} }}";
                }
            }
        }
    }
}