namespace MooVC.Syntax.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.Elements.Snippet_Resources;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Defines options for the Snippet syntax element.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            /// <summary>
            /// Gets the default instance.
            /// </summary>
            public static readonly Options Default = new Options();

            /// <summary>
            /// Gets or sets the block on the Options.
            /// </summary>
            /// <value>The block.</value>
            [Required(ErrorMessageResourceName = nameof(OptionsBlockRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BlockOptions Block { get; internal set; } = new BlockOptions();

            /// <summary>
            /// Gets a value indicating whether the Options is default.
            /// </summary>
            /// <value>A value indicating whether the Options is default.</value>
            [Valuify.Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets or sets the max length on the Options.
            /// </summary>
            /// <value>The max length.</value>
            [Range(120, 255, ErrorMessageResourceName = nameof(OptionsMaxLengthOutOfRange), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public byte MaxLength { get; internal set; } = 155;

            /// <summary>
            /// Gets or sets the whitespace on the Options.
            /// </summary>
            /// <value>The whitespace.</value>
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsWhitespaceRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public Snippet Whitespace { get; internal set; } = StringExtensions.ToSnippet("    ");
        }
    }
}