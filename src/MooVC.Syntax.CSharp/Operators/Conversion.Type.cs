namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    /// <summary>
    /// Represents a c# operator syntax conversion.
    /// </summary>
    public partial class Conversion
    {
        /// <summary>
        /// Represents a c# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Type
        {
            /// <summary>
            /// Gets the explicit on the Type.
            /// </summary>
            public static readonly Type Explicit = "explicit";
            /// <summary>
            /// Gets the implicit on the Type.
            /// </summary>
            public static readonly Type Implicit = "implicit";

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is explicit.
            /// </summary>
            public bool IsExplicit => this == Explicit;

            /// <summary>
            /// Gets a value indicating whether the Type is implicit.
            /// </summary>
            public bool IsImplicit => this == Implicit;

            /// <summary>
            /// Returns the string representation of the Type.
            /// </summary>
            public override string ToString()
            {
                return _value;
            }
        }
    }
}