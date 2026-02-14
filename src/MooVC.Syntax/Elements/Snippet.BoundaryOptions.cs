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
        /// Represents a syntax element boundary options.
        /// </summary>
        [AutoInitializeWith(nameof(Default))]
        [Fluentify]
        [Valuify]
        public sealed partial class BoundaryOptions
        {
            /// <summary>
            /// Gets the default set of options for boundary operations.
            /// </summary>
            /// <remarks>
            /// Use this instance as a baseline when configuring boundary-related settings,
            /// or when no custom options are required.
            /// </remarks>
            public static readonly BoundaryOptions Default = new BoundaryOptions();

            /// <summary>
            /// Initializes a new instance of the BoundaryOptions class.
            /// </summary>
            internal BoundaryOptions()
            {
            }

            /// <summary>
            /// Gets the closing on the BoundaryOptions.
            /// </summary>
            /// <value>The closing.</value>
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(BoundaryClosingRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Closing { get; set; } = "}";

            /// <summary>
            /// Gets a value indicating whether this instance represents the default value.
            /// </summary>
            /// <value>
            /// A value indicating whether this instance represents the default value.
            /// </value>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets the opening on the BoundaryOptions.
            /// </summary>
            /// <value>The opening.</value>
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(BoundaryOpeningRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Opening { get; set; } = "{";
        }
    }
}