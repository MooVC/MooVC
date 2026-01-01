namespace MooVC.Syntax.Elements
{
    using Monify;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Represents a syntax element block options.
        /// </summary>
        public partial class BlockOptions
        {
            /// <summary>
            /// Represents a syntax element inline style.
            /// </summary>
            [Monify(Type = typeof(int))]
            public partial class InlineStyle
            {
                /// <summary>
                /// Gets the lambda on the InlineStyle.
                /// </summary>
                public static readonly InlineStyle Lambda = 0;
                /// <summary>
                /// Gets the single line braces on the InlineStyle.
                /// </summary>
                public static readonly InlineStyle SingleLineBraces = 1;
                /// <summary>
                /// Gets the multi line braces on the InlineStyle.
                /// </summary>
                public static readonly InlineStyle MultiLineBraces = 2;

                private InlineStyle(int value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the InlineStyle is lambda.
                /// </summary>
                public bool IsLambda => this == Lambda;

                /// <summary>
                /// Gets a value indicating whether the InlineStyle is single line braces.
                /// </summary>
                public bool IsSingleLineBraces => this == SingleLineBraces;

                /// <summary>
                /// Gets a value indicating whether the InlineStyle is multi line braces.
                /// </summary>
                public bool IsMultiLineBraces => this == MultiLineBraces;
            }
        }
    }
}