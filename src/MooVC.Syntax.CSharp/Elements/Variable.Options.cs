namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# syntax element variable.
    /// </summary>
    partial class Variable
    {
        /// <summary>
        /// Defines options for the Variable C# syntax element.
        /// </summary>
        [AutoInitiateWith(nameof(Camel))]
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the camel for the Options.
            /// </summary>
            public static readonly Options Camel = new Options();

            /// <summary>
            /// Represents the pascal for the Options.
            /// </summary>
            public static readonly Options Pascal = new Options { Casing = Identifier.Casing.Pascal };

            /// <summary>
            /// Gets or sets the casing on the Options.
            /// </summary>
            /// <value>The casing.</value>
            public Identifier.Casing Casing { get; set; } = Identifier.Casing.Camel;

            /// <summary>
            /// Gets a value indicating whether the Options is camel.
            /// </summary>
            /// <value>A value indicating whether the Options is camel.</value>
            [Ignore]
            public bool IsCamel => Casing == Identifier.Casing.Pascal;

            /// <summary>
            /// Gets a value indicating whether the Options is pascal.
            /// </summary>
            /// <value>A value indicating whether the Options is pascal.</value>
            [Ignore]
            public bool IsPascal => Casing == Identifier.Casing.Pascal;

            /// <summary>
            /// Gets a value indicating whether or not to use underscore for variabel names.
            /// </summary>
            /// <value>A value indicating whether or not to use underscore for variabel names.</value>
            public bool UseUnderscore { get; internal set; }

            /// <summary>
            /// Defines the Identifier.Options operator for the Options.
            /// </summary>
            /// <param name="options">The options.</param>
            /// <returns>The identifier options.</returns>
            public static implicit operator Identifier.Options(Options options)
            {
                Guard.Against.Conversion<Options, Identifier.Options>(options);

                return new Identifier.Options
                {
                    Casing = options.Casing,
                };
            }
        }
    }
}