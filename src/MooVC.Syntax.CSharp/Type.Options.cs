namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# type symbol.
    /// </summary>
    public partial class Type
    {
        /// <summary>
        /// Represents a C# type syntax options.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the default instance.
            /// </summary>
            public static readonly Options Default = new Options();

            /// <summary>
            /// Gets a value indicating whether the Options is default.
            /// </summary>
            /// <value>A value indicating whether the Options is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets the snippets options.
            /// </summary>
            /// <value>The snippets options.</value>
            public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default;

            /// <summary>
            /// Gets the symbol options.
            /// </summary>
            /// <value>The symbol options.</value>
            public Symbol.Options Types { get; internal set; } = Symbol.Options.Default;

            /// <summary>
            /// Converts type options into snippet options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The snippet options.</returns>
            public static implicit operator Snippet.Options(Options options)
            {
                Guard.Against.Conversion<Options, Snippet.Options>(options);

                return options.Snippets;
            }

            /// <summary>
            /// Converts type options into symbol options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The symbol options.</returns>
            public static implicit operator Symbol.Options(Options options)
            {
                Guard.Against.Conversion<Options, Symbol.Options>(options);

                return options.Types;
            }
        }
    }
}