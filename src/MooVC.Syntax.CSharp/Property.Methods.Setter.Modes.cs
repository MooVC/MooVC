namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Monify;

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
            public partial class Setter
            {
                /// <summary>
                /// Represents the setter access mode used by property accessors.
                /// </summary>
                [Monify(Type = typeof(string))]
                [SkipAutoInitialization]
                public sealed partial class Modes
                {
                    /// <summary>
                    /// Represents the init for the Mode.
                    /// </summary>
                    public static readonly Modes Init = "Init";

                    /// <summary>
                    /// Represents the read only for the Mode.
                    /// </summary>
                    public static readonly Modes ReadOnly = "ReadOnly";

                    /// <summary>
                    /// Represents the set for the Mode.
                    /// </summary>
                    public static readonly Modes Set = "Set";

                    private Modes(string value)
                    {
                        _value = value;
                    }

                    /// <summary>
                    /// Gets a value indicating whether the Mode is init.
                    /// </summary>
                    /// <value>A value indicating whether the Mode is init.</value>
                    public bool IsInit => this == Init;

                    /// <summary>
                    /// Gets a value indicating whether the Mode is read only.
                    /// </summary>
                    /// <value>A value indicating whether the Mode is read only.</value>
                    public bool IsReadOnly => this == ReadOnly;

                    /// <summary>
                    /// Gets a value indicating whether the Mode is set.
                    /// </summary>
                    /// <value>A value indicating whether the Mode is set.</value>
                    public bool IsSet => this == Set;

                    /// <summary>
                    /// Returns the string representation of the Mode.
                    /// </summary>
                    /// <returns>The string representation.</returns>
                    public override string ToString()
                    {
                        if (IsInit)
                        {
                            return "init";
                        }

                        if (IsSet)
                        {
                            return "set";
                        }

                        return string.Empty;
                    }
                }
            }
        }
    }
}