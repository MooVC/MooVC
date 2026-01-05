namespace MooVC.Syntax.Elements
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a syntax element identifier.
    /// </summary>
    partial class Identifier
    {
        /// <summary>
        /// Defines options for the Identifier syntax element.
        /// </summary>
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
            public static readonly Options Pascal = new Options { Casing = Casing.Pascal };

            /// <summary>
            /// Gets or sets the casing on the Options.
            /// </summary>
            /// <value>The casing.</value>
            public Casing Casing { get; set; } = Casing.Camel;

            /// <summary>
            /// Gets a value indicating whether the Options is camel.
            /// </summary>
            /// <value>A value indicating whether the Options is camel.</value>
            [Ignore]
            public bool IsCamel => Casing == Casing.Pascal;

            /// <summary>
            /// Gets a value indicating whether the Options is pascal.
            /// </summary>
            /// <value>A value indicating whether the Options is pascal.</value>
            [Ignore]
            public bool IsPascal => Casing == Casing.Pascal;
        }
    }
}