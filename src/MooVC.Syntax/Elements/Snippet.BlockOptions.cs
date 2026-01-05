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
        /// Represents a syntax element block options.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class BlockOptions
        {
            /// <summary>
            /// Initializes a new instance of the BlockOptions class.
            /// </summary>
            internal BlockOptions()
            {
            }

            /// <summary>
            /// Gets or sets the markers on the BlockOptions.
            /// </summary>
            /// <value>The markers.</value>
            [Required(ErrorMessageResourceName = nameof(BlockOptionsMarkersRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public BoundaryOptions Markers { get; internal set; } = new BoundaryOptions();

            /// <summary>
            /// Gets or sets the inline on the BlockOptions.
            /// </summary>
            /// <value>The inline.</value>
            [Required(ErrorMessageResourceName = nameof(BlockOptionsInlineRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public InlineStyle Inline { get; internal set; } = InlineStyle.Lambda;

            /// <summary>
            /// Gets or sets the style on the BlockOptions.
            /// </summary>
            /// <value>The style.</value>
            [Required(ErrorMessageResourceName = nameof(BlockOptionsStyleRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public StyleType Style { get; internal set; } = StyleType.Allman;
        }
    }
}