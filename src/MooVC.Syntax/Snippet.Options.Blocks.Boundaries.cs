namespace MooVC.Syntax
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
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
            public partial class Blocks
            {
                /// <summary>
                /// Represents a syntax element boundary options.
                /// </summary>
                [AutoInitializeWith(nameof(Default))]
                [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
                [Fluentify]
                [Valuify]
                public sealed partial class Boundaries
                {
                    /// <summary>
                    /// Gets the default set of options for boundary operations.
                    /// </summary>
                    /// <remarks>
                    /// Use this instance as a baseline when configuring boundary-related settings,
                    /// or when no custom options are required.
                    /// </remarks>
                    public static readonly Boundaries Default = new Boundaries();

                    /// <summary>
                    /// Initializes a new instance of the BoundaryOptions class.
                    /// </summary>
                    internal Boundaries()
                    {
                    }

                    /// <summary>
                    /// Gets the closing on the BoundaryOptions.
                    /// </summary>
                    /// <value>The closing.</value>
                    [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsBlockBoundariesClosingRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
                    public string Closing { get; internal set; } = "}";

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
                    [Required(AllowEmptyStrings = false, ErrorMessageResourceName = nameof(OptionsBlockBoundariesOpeningRequired), ErrorMessageResourceType = typeof(Snippet_Resources))]
                    public string Opening { get; internal set; } = "{";

                    private string GetDebuggerDisplay()
                    {
                        return $"{nameof(Boundaries)} {{ {nameof(Closing)} = {DebuggerDisplayFormatter.Format(Closing)}, {nameof(IsDefault)} = {DebuggerDisplayFormatter.Format(IsDefault)}, {nameof(Opening)} = {DebuggerDisplayFormatter.Format(Opening)} }}";
                    }
                }
            }
        }
    }
}