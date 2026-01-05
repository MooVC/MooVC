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
                /// Represents the lambda for the InlineStyle.
                /// </summary>
                public static readonly InlineStyle Lambda = 0;

                /// <summary>
                /// Represents the single line braces for the InlineStyle.
                /// </summary>
                public static readonly InlineStyle SingleLineBraces = 1;

                /// <summary>
                /// Represents the multi line braces for the InlineStyle.
                /// </summary>
                public static readonly InlineStyle MultiLineBraces = 2;

                private InlineStyle(int value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the InlineStyle is lambda.
                /// </summary>
                /// <value>A value indicating whether the InlineStyle is lambda.</value>
                public bool IsLambda => this == Lambda;

                /// <summary>
                /// Gets a value indicating whether the InlineStyle is single line braces.
                /// </summary>
                /// <value>A value indicating whether the InlineStyle is single line braces.</value>
                public bool IsSingleLineBraces => this == SingleLineBraces;

                /// <summary>
                /// Gets a value indicating whether the InlineStyle is multi line braces.
                /// </summary>
                /// <value>A value indicating whether the InlineStyle is multi line braces.</value>
                public bool IsMultiLineBraces => this == MultiLineBraces;
            }
        }
    }
}