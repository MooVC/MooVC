namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a parameter signature component used by members and delegates.
    /// </summary>
    public partial class Attribute
    {
        /// <summary>
        /// Defines rendering options for attribute declarations.
        /// </summary>
        public partial class Options
        {
            /// <summary>
            /// Defines formatting styles for rendering attributes.
            /// </summary>
            [Monify(Type = typeof(string))]
            [SkipAutoInitialization]
            public sealed partial class Styles
            {
                /// <summary>
                /// Represents the inline style option.
                /// </summary>
                public static readonly Styles Inline = "Inline";

                /// <summary>
                /// Represents a style that separates elements or content according to a predefined rule.
                /// </summary>
                public static readonly Styles Separate = "Separate";

                private Styles(string value)
                {
                    _value = value;
                }

                /// <summary>
                /// Gets a value indicating whether the current instance represents inline content.
                /// </summary>
                /// <value>
                /// A value indicating whether the current instance represents inline content.
                /// </value>
                public bool IsInline => this == Inline;

                /// <summary>
                /// Gets a value indicating whether the current instance represents a separate value.
                /// </summary>
                /// <value>
                /// A value indicating whether the current instance represents a separate value.
                /// </value>
                public bool IsSeparate => this == Separate;
            }
        }
    }
}