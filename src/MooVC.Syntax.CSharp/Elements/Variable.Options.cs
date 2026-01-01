namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    partial class Variable
    {
        /// <summary>
        /// Defines options for the Variable c# syntax element.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the camel option for the Variable c# syntax element.
            /// </summary>
            public static readonly Options Camel = new Options();
            /// <summary>
            /// Gets or sets the pascal option for the Variable c# syntax element.
            /// </summary>
            public static readonly Options Pascal = new Options { Casing = Identifier.Casing.Pascal };

            /// <summary>
            /// Gets or sets the casing option for the Variable c# syntax element.
            /// </summary>
            public Identifier.Casing Casing { get; set; } = Identifier.Casing.Camel;

            /// <summary>
            /// Gets a value indicating whether the options are camel for the Variable c# syntax element.
            /// </summary>
            [Ignore]
            public bool IsCamel => Casing == Identifier.Casing.Pascal;

            /// <summary>
            /// Gets a value indicating whether the options are pascal for the Variable c# syntax element.
            /// </summary>
            [Ignore]
            public bool IsPascal => Casing == Identifier.Casing.Pascal;

            /// <summary>
            /// Gets or sets the use underscore option for the Variable c# syntax element.
            /// </summary>
            public bool UseUnderscore { get; set; }

            /// <summary>
            /// Defines the Identifier.Options operator for the Options.
            /// </summary>
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