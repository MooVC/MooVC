namespace MooVC.Syntax.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.Elements.Snippet_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Represents a syntax element block options.
        /// </summary>
        [AutoInitiateWith(nameof(Default))]
        [Fluentify]
        [Valuify]
        public sealed partial class BlockOptions
        {
            /// <summary>
            /// Gets the default set of options for a block operation.
            /// </summary>
            /// <remarks>
            /// Use this instance as a baseline when configuring block operations to ensure
            /// consistent default behavior. Modifying the properties of this instance does not affect other
            /// instances.
            /// </remarks>
            public static readonly BlockOptions Default = new BlockOptions();

            /// <summary>
            /// Initializes a new instance of the BlockOptions class.
            /// </summary>
            internal BlockOptions()
            {
            }

            /// <summary>
            /// Gets a value indicating whether this instance represents the default value.
            /// </summary>
            /// <value>
            /// A value indicating whether this instance represents the default value.
            /// </value>
            [Ignore]
            public bool IsDefault => this == Default;

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