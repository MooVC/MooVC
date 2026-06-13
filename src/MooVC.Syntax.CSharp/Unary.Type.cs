namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a unary operator declaration model.
    /// </summary>
    public partial class Unary
    {
        /// <summary>
        /// Represents an operator token category used by operator declarations.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Types
        {
            /// <summary>
            /// Represents the complement for the Type.
            /// </summary>
            public static readonly Types Complement = "~";

            /// <summary>
            /// Represents the decrement for the Type.
            /// </summary>
            public static readonly Types Decrement = "--";

            /// <summary>
            /// Represents the <see langword="false" /> for the Type.
            /// </summary>
            public static readonly Types False = "false";

            /// <summary>
            /// Represents the increment for the Type.
            /// </summary>
            public static readonly Types Increment = "++";

            /// <summary>
            /// Represents the minus for the Type.
            /// </summary>
            public static readonly Types Minus = "-";

            /// <summary>
            /// Represents the not for the Type.
            /// </summary>
            public static readonly Types Not = "!";

            /// <summary>
            /// Represents the plus for the Type.
            /// </summary>
            public static readonly Types Plus = "+";

            /// <summary>
            /// Represents the <see langword="true" /> for the Type.
            /// </summary>
            public static readonly Types True = "true";

            /// <summary>
            /// Gets the unspecified instance.
            /// </summary>
            public static readonly Types Unspecified = string.Empty;

            private Types(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is complement.
            /// </summary>
            /// <value>A value indicating whether the Type is complement.</value>
            public bool IsComplement => this == Complement;

            /// <summary>
            /// Gets a value indicating whether the Type is decrement.
            /// </summary>
            /// <value>A value indicating whether the Type is decrement.</value>
            public bool IsDecrement => this == Decrement;

            /// <summary>
            /// Gets a value indicating whether the Type is <see langword="false" />.
            /// </summary>
            /// <value>A value indicating whether the Type is <see langword="false" />.</value>
            public bool IsFalse => this == False;

            /// <summary>
            /// Gets a value indicating whether the Type is increment.
            /// </summary>
            /// <value>A value indicating whether the Type is increment.</value>
            public bool IsIncrement => this == Increment;

            /// <summary>
            /// Gets a value indicating whether the Type is minus.
            /// </summary>
            /// <value>A value indicating whether the Type is minus.</value>
            public bool IsMinus => this == Minus;

            /// <summary>
            /// Gets a value indicating whether the Type is not.
            /// </summary>
            /// <value>A value indicating whether the Type is not.</value>
            public bool IsNot => this == Not;

            /// <summary>
            /// Gets a value indicating whether the Type is plus.
            /// </summary>
            /// <value>A value indicating whether the Type is plus.</value>
            public bool IsPlus => this == Plus;

            /// <summary>
            /// Gets a value indicating whether the Type is <see langword="true" />.
            /// </summary>
            /// <value>A value indicating whether the Type is <see langword="true" />.</value>
            public bool IsTrue => this == True;

            /// <summary>
            /// Gets a value indicating whether the Type is unspecified.
            /// </summary>
            /// <value>A value indicating whether the Type is unspecified.</value>
            public bool IsUnspecified => this == Unspecified;
        }
    }
}