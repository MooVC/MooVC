namespace MooVC.Syntax
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Defines options for the Snippet syntax element.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Represents a syntax element block options.
            /// </summary>
            public partial class Blocks
            {
                /// <summary>
                /// Represents a syntax element inline style.
                /// </summary>
                [Monify(Type = typeof(string))]
                [SkipAutoInitialization]
                public partial class Styles
                {
                    /// <summary>
                    /// Represents the lambda for the InlineStyle.
                    /// </summary>
                    public static readonly Styles Lambda = "Lambda";

                    /// <summary>
                    /// Represents the single line braces for the InlineStyle.
                    /// </summary>
                    public static readonly Styles SingleLine = "SingleLine";

                    /// <summary>
                    /// Represents the multi line braces for the InlineStyle.
                    /// </summary>
                    public static readonly Styles MultiLine = "MultiLine";

                    private Styles(string value)
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
                    public bool IsSingleLine => this == SingleLine;

                    /// <summary>
                    /// Gets a value indicating whether the InlineStyle is multi line braces.
                    /// </summary>
                    /// <value>A value indicating whether the InlineStyle is multi line braces.</value>
                    public bool IsMultiLine => this == MultiLine;

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string representation of the current object.</returns>
                    public override string ToString()
                    {
                        return _value;
                    }
                }
            }
        }
    }
}