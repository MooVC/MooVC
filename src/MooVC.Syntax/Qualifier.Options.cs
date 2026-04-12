namespace MooVC.Syntax
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a syntax element qualifier.
    /// </summary>
    public partial class Qualifier
    {
        /// <summary>
        /// Defines options for the Qualifier syntax element.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Options
        {
            /// <summary>
            /// Represents the block for the Options.
            /// </summary>
            public static readonly Options Block = "Block";

            /// <summary>
            /// Represents the file for the Options.
            /// </summary>
            public static readonly Options File = "File";

            private Options(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Options is block.
            /// </summary>
            /// <value>A value indicating whether the Options is block.</value>
            public bool IsBlock => this == Block;

            /// <summary>
            /// Gets a value indicating whether the Options is file.
            /// </summary>
            /// <value>A value indicating whether the Options is file.</value>
            public bool IsFile => this == File;

            /// <summary>
            /// Returns the string representation of the Options.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}