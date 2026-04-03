namespace MooVC.Syntax
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.Snippet_Resources;
    using Ignore = Valuify.IgnoreAttribute;
    using Strings = MooVC.Syntax.Formatting.StringExtensions;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Defines options for the Snippet syntax element.
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
            /// Represents an options instance with unspecified or default values.
            /// </summary>
            /// <remarks>
            /// Use this field to indicate that no specific options have been set. This can
            /// be useful as a sentinel value or when an explicit 'unspecified' state is required.
            /// </remarks>
            public static readonly Options Unspecified = new Options(true);

            [SuppressMessage("Style", "IDE0032:Use auto property", Justification = "Fields are not set by Fluentify")]
            private readonly bool _isUnspecified;

            /// <summary>
            /// Initializes a new instance of the Options class.
            /// </summary>
            public Options()
            {
            }

            private Options(bool isUnspecified)
            {
                _isUnspecified = isUnspecified;
            }

            /// <summary>
            /// Gets the block on the Options.
            /// </summary>
            /// <value>The block.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsBlockRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BlockOptions Block { get; internal set; } = BlockOptions.Default;

            /// <summary>
            /// Gets the chaining on the Options.
            /// </summary>
            /// <value>The block.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsChainingRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public ChainingOptions Chaining { get; internal set; } = ChainingOptions.Default;

            /// <summary>
            /// Gets a value indicating whether the Options is default.
            /// </summary>
            /// <value>A value indicating whether the Options is default.</value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets a value indicating whether the current instance is unspecified.
            /// </summary>
            /// <value>
            /// A value indicating whether the current instance is unspecified.
            /// </value>
            [Ignore]
            public bool IsUnspecified => _isUnspecified;

            /// <summary>
            /// Gets the max length on the Options.
            /// </summary>
            /// <value>The max length.</value>
            [Range(120, 255, ErrorMessageResourceName = nameof(OptionsMaxLengthOutOfRange), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public byte MaxLength { get; internal set; } = 155;

            /// <summary>
            /// Gets the whitespace on the Options.
            /// </summary>
            /// <value>The whitespace.</value>
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsWhitespaceRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public Snippet Whitespace { get; internal set; } = Strings.ToSnippet("    ");
        }
    }
}