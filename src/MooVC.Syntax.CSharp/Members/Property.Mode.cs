namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a C# member syntax property.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Represents a C# member syntax mode.
        /// </summary>
        [Monify(Type = typeof(int))]
        [SkipAutoInitialization]
        public sealed partial class Mode
        {
            /// <summary>
            /// Represents the init for the Mode.
            /// </summary>
            public static readonly Mode Init = 2;

            /// <summary>
            /// Represents the read only for the Mode.
            /// </summary>
            public static readonly Mode ReadOnly = 1;

            /// <summary>
            /// Represents the set for the Mode.
            /// </summary>
            public static readonly Mode Set = 0;

            private Mode(int value)
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