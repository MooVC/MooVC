namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a property declaration model.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Represents accessor methods used by indexers, properties, and events.
        /// </summary>
        public partial class Methods
        {
            /// <summary>
            /// Represents a property setter accessor configuration.
            /// </summary>
            [AutoInitializeWith(nameof(Default))]
            [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
            [Fluentify]
            [Valuify]
            public sealed partial class Setter
            {
                /// <summary>
                /// Gets the default instance.
                /// </summary>
                public static readonly Setter Default = new Setter();

                /// <summary>
                /// Initializes a new instance of the Setter class.
                /// </summary>
                internal Setter()
                {
                }

                /// <summary>
                /// Gets the behaviour on the Setter.
                /// </summary>
                /// <value>The behaviour.</value>
                public Snippet Behaviour { get; internal set; } = Snippet.Empty;

                /// <summary>
                /// Gets a value indicating whether the Setter is default.
                /// </summary>
                /// <value>A value indicating whether the Setter is default.</value>
                [Ignore]
                public bool IsDefault => this == Default;

                /// <summary>
                /// Gets the mode on the Setter.
                /// </summary>
                /// <value>The mode.</value>
                public Modes Mode { get; internal set; } = Modes.Init;

                /// <summary>
                /// Gets the scope on the Setter.
                /// </summary>
                /// <value>The scope.</value>
                public Scopes Scope { get; internal set; } = Scopes.Unspecified;

                private string GetDebuggerDisplay()
                {
                    return $"{nameof(Setter)} {{ {nameof(Behaviour)} = {DebuggerDisplayFormatter.Format(Behaviour)}, {nameof(IsDefault)} = {DebuggerDisplayFormatter.Format(IsDefault)}, {nameof(Mode)} = {DebuggerDisplayFormatter.Format(Mode)}, {nameof(Scope)} = {DebuggerDisplayFormatter.Format(Scope)} }}";
                }
            }
        }
    }
}