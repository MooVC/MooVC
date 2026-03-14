namespace MooVC.Syntax.Elements
{
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.Elements.Snippet_Resources;
    using static MooVC.Syntax.Elements.Snippet.BlockOptions;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a syntax element snippet.
    /// </summary>
    public partial class Snippet
    {
        /// <summary>
        /// Represents a syntax element boundary options.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [Fluentify]
        [Valuify]
        public sealed partial class InlineOptions
        {
            /// <summary>
            /// Gets the default set of options for inline operations.
            /// </summary>
            /// <remarks>
            /// Use this instance as a baseline when configuring inline-related settings,
            /// or when no custom options are required.
            /// </remarks>
            public static readonly InlineOptions Default = new InlineOptions();

            /// <summary>
            /// Initializes a new instance of the BoundaryOptions class.
            /// </summary>
            internal InlineOptions()
            {
            }

            /// <summary>
            /// Gets the inline for Methods.
            /// </summary>
            /// <value>The style for Methods.</value>
            [Required(ErrorMessageResourceName = nameof(InlineMethodsRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public InlineStyle Code { get; internal set; } = InlineStyle.MultiLineBraces;

            /// <summary>
            /// Gets a value indicating whether this instance represents the default value.
            /// </summary>
            /// <value>
            /// A value indicating whether this instance represents the default value.
            /// </value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets the inline for Methods.
            /// </summary>
            /// <value>The style for Methods.</value>
            [Required(ErrorMessageResourceName = nameof(InlineMethodsRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public InlineStyle Methods { get; internal set; } = InlineStyle.MultiLineBraces;

            /// <summary>
            /// Gets the inline for Properties.
            /// </summary>
            /// <value>The style for Properties.</value>
            [Required(ErrorMessageResourceName = nameof(InlinePropertiesRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public InlineStyle Properties { get; internal set; } = InlineStyle.Lambda;
        }
    }
}