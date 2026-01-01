namespace MooVC.Syntax.CSharp.Elements
{
    using Fluentify;
    using Valuify;

    /// <summary>
    /// Represents a c# syntax element symbol.
    /// </summary>
    public partial class Symbol
    {
        /// <summary>
        /// Defines options for the Symbol c# syntax element.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the default options for the Symbol c# syntax element.
            /// </summary>
            public static readonly Options Default = new Options();

            /// <summary>
            /// Gets or sets the qualification option for the Symbol c# syntax element.
            /// </summary>
            public Qualification Qualification { get; set; } = Qualification.Minimum;
        }
    }
}