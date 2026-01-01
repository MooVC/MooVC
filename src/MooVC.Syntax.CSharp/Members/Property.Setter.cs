namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# member syntax property.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Represents a c# member syntax setter.
        /// </summary>
        [Fluentify]
        [Valuify]
        public sealed partial class Setter
        {
            /// <summary>
            /// Gets the default on the Setter.
            /// </summary>
            public static readonly Setter Default = new Setter();

            /// <summary>
            /// Initializes a new instance of the Setter class.
            /// </summary>
            internal Setter()
            {
            }

            /// <summary>
            /// Gets or sets the behaviour on the Setter.
            /// </summary>
            public Snippet Behaviour { get; internal set; } = Snippet.Empty;

            /// <summary>
            /// Gets a value indicating whether the Setter is default.
            /// </summary>
            [Ignore]
            public bool IsDefault => this == Default;

            /// <summary>
            /// Gets or sets the mode on the Setter.
            /// </summary>
            public Mode Mode { get; internal set; } = Mode.Set;

            /// <summary>
            /// Gets or sets the scope on the Setter.
            /// </summary>
            public Scope Scope { get; internal set; } = Scope.Unspecified;
        }
    }
}