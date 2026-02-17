namespace MooVC.Syntax.CSharp.Elements
{
    using Fluentify;
    using Valuify;

    /// <summary>
    /// Represents a C# syntax element symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Defines options for the Symbol C# syntax element.
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
            /// Gets the qualification on the Options.
            /// </summary>
            /// <value>The qualification.</value>
            public Qualification Qualification { get; set; } = Qualification.Minimum;
        }
    }
}