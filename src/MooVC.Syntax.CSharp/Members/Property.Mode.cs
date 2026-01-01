namespace MooVC.Syntax.CSharp.Members
{
    using Monify;

    /// <summary>
    /// Represents a c# member syntax property.
    /// </summary>
    public partial class Property
    {
        /// <summary>
        /// Represents a c# member syntax mode.
        /// </summary>
        [Monify(Type = typeof(int))]
        public sealed partial class Mode
        {
            /// <summary>
            /// Gets the init on the Mode.
            /// </summary>
            public static readonly Mode Init = 2;
            /// <summary>
            /// Gets the read only on the Mode.
            /// </summary>
            public static readonly Mode ReadOnly = 1;
            /// <summary>
            /// Gets the set on the Mode.
            /// </summary>
            public static readonly Mode Set = 0;

            private Mode(int value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Mode is init.
            /// </summary>
            public bool IsInit => this == Init;

            /// <summary>
            /// Gets a value indicating whether the Mode is read only.
            /// </summary>
            public bool IsReadOnly => this == ReadOnly;

            /// <summary>
            /// Gets a value indicating whether the Mode is set.
            /// </summary>
            public bool IsSet => this == Set;

            /// <summary>
            /// Returns the string representation of the Mode.
            /// </summary>
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