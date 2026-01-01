namespace MooVC.Syntax.Elements
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
        [Monify(Type = typeof(int))]
        [SkipAutoInstantiation]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the block option for the Qualifier syntax element.
            /// </summary>
            public static readonly Options Block = 1;
            /// <summary>
            /// Gets the file option for the Qualifier syntax element.
            /// </summary>
            public static readonly Options File = 0;

            private Options(int value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the options are block for the Qualifier syntax element.
            /// </summary>
            public bool IsBlock => this == Block;

            /// <summary>
            /// Gets a value indicating whether the options are file for the Qualifier syntax element.
            /// </summary>
            public bool IsFile => this == File;

            /// <summary>
            /// Returns the string representation of the Options.
            /// </summary>
            public override string ToString()
            {
                if (IsBlock)
                {
                    return nameof(Block);
                }

                return nameof(File);
            }
        }
    }
}