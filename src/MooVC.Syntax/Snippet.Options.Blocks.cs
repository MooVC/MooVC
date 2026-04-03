namespace MooVC.Syntax
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.Snippet_Resources;
    using Ignore = Valuify.IgnoreAttribute;

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
            [AutoInitializeWith(nameof(Default))]
            [Fluentify]
            [Valuify]
            public sealed partial class Blocks
            {
                /// <summary>
                /// Gets the default set of options for a block operation.
                /// </summary>
                /// <remarks>
                /// Use this instance as a baseline when configuring block operations to ensure
                /// consistent default behavior. Modifying the properties of this instance does not affect other
                /// instances.
                /// </remarks>
                public static readonly Blocks Default = new Blocks();

                /// <summary>
                /// Initializes a new instance of the BlockOptions class.
                /// </summary>
                internal Blocks()
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
                /// Gets the inline on the BlockOptions.
                /// </summary>
                /// <value>The inline.</value>
                [Required(ErrorMessageResourceName = nameof(OptionsBlocksInlineRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
                public Styles Inline { get; internal set; } = Styles.MultiLine;

                /// <summary>
                /// Gets the markers on the BlockOptions.
                /// </summary>
                /// <value>The markers.</value>
                [Required(ErrorMessageResourceName = nameof(OptionsBlocksMarkersRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
                public Boundaries Markers { get; internal set; } = Boundaries.Default;

                /// <summary>
                /// Gets the style on the BlockOptions.
                /// </summary>
                /// <value>The style.</value>
                [Required(ErrorMessageResourceName = nameof(OptionsBlocksLayoutRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
                public Layouts Layout { get; internal set; } = Layouts.Allman;
            }
        }
    }
}