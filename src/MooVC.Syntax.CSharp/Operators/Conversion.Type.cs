namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    /// <summary>
    /// Represents a C# operator syntax conversion.
    /// </summary>
    public partial class Conversion
    {
        /// <summary>
        /// Represents a C# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Type
        {
            /// <summary>
            /// Represents the explicit for the Type.
            /// </summary>
            public static readonly Type Explicit = "explicit";
            /// <summary>
            /// Represents the implicit for the Type.
            /// </summary>
            public static readonly Type Implicit = "implicit";

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is explicit.
            /// </summary>
            /// <value>A value indicating whether the Type is explicit.</value>
            public bool IsExplicit => this == Explicit;

            /// <summary>
            /// Gets a value indicating whether the Type is implicit.
            /// </summary>
            /// <value>A value indicating whether the Type is implicit.</value>
            public bool IsImplicit => this == Implicit;

            /// <summary>
            /// Returns the string representation of the Type.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}