namespace MooVC.Syntax.CSharp
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents an identifier token used for names in generated C# code.
    /// </summary>
    public partial class Variable
    {
        /// <summary>
        /// Defines naming options used when rendering identifiers.
        /// </summary>
        [AutoInitializeWith(nameof(Camel))]
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
            /// Gets the casing on the Options.
            /// </summary>
            /// <value>The casing.</value>
            public Identifier.Casing Casing { get; internal set; } = Identifier.Casing.Camel;

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
            /// <summary>
            /// Converts variable options into identifier options.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The identifier options.</returns>
            public static implicit operator Identifier.Options(Options options)
            {
                Guard.Against.Conversion<Options, Identifier.Options>(options);

                return new Identifier.Options()
                    .WithCasing(options.Casing);
            }

            /// <summary>
            /// Converts variable options into identifier casing.
            /// </summary>
            /// <param name="options">The source options.</param>
            /// <returns>The identifier casing.</returns>
            public static implicit operator Identifier.Casing(Options options)
            {
                Guard.Against.Conversion<Options, Identifier.Casing>(options);

                return options.Casing;
            }
        }
    }
}