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
        /// Represents a syntax element boundary options.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class BoundaryOptions
        {
            /// <summary>
            /// Initializes a new instance of the BoundaryOptions class.
            /// </summary>
            internal BoundaryOptions()
            {
            }

            /// <summary>
            /// Gets or sets the closing on the BoundaryOptions.
            /// </summary>
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(BoundaryClosingRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Closing { get; set; } = "}";

            /// <summary>
            /// Gets or sets the opening on the BoundaryOptions.
            /// </summary>
            [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(BoundaryOpeningRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
            public string Opening { get; set; } = "{";
        }
    }
}