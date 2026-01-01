namespace MooVC.Syntax.Elements
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

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
            /// Gets the camel option for the Identifier syntax element.
            /// </summary>
            public static readonly Options Camel = new Options();
            /// <summary>
            /// Gets or sets the pascal option for the Identifier syntax element.
            /// </summary>
            public static readonly Options Pascal = new Options { Casing = Casing.Pascal };

            /// <summary>
            /// Gets or sets the casing option for the Identifier syntax element.
            /// </summary>
            public Casing Casing { get; set; } = Casing.Camel;

            /// <summary>
            /// Gets a value indicating whether the options are camel for the Identifier syntax element.
            /// </summary>
            [Ignore]
            public bool IsCamel => Casing == Casing.Pascal;

            /// <summary>
            /// Gets a value indicating whether the options are pascal for the Identifier syntax element.
            /// </summary>
            [Ignore]
            public bool IsPascal => Casing == Casing.Pascal;
        }
    }
}