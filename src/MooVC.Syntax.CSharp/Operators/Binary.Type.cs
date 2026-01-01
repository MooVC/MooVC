namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    /// <summary>
    /// Represents a C# operator syntax binary.
    /// </summary>
    public partial class Binary
    {
        /// <summary>
        /// Represents a C# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Type
            : IComparable<Type>
        {
            /// <summary>
            /// Represents the add for the Type.
            /// </summary>
            public static readonly Type Add = "+";
            /// <summary>
            /// Represents the and for the Type.
            /// </summary>
            public static readonly Type And = "&";
            /// <summary>
            /// Represents the divide for the Type.
            /// </summary>
            public static readonly Type Divide = "/";
            /// <summary>
            /// Represents the left for the Type.
            /// </summary>
            public static readonly Type Left = "<<";
            /// <summary>
            /// Represents the modulus for the Type.
            /// </summary>
            public static readonly Type Modulus = "%";
            /// <summary>
            /// Represents the multiply for the Type.
            /// </summary>
            public static readonly Type Multiply = "*";
            /// <summary>
            /// Represents the or for the Type.
            /// </summary>
            public static readonly Type Or = "|";
            /// <summary>
            /// Represents the right for the Type.
            /// </summary>
            public static readonly Type Right = ">>";
            /// <summary>
            /// Represents the subtract for the Type.
            /// </summary>
            public static readonly Type Subtract = "-";
            /// <summary>
            /// Gets the unspecified instance.
            /// </summary>
            public static readonly Type Unspecified = string.Empty;
            /// <summary>
            /// Represents the xor for the Type.
            /// </summary>
            public static readonly Type XOR = "^";

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is add.
            /// </summary>
            /// <value>A value indicating whether the Type is add.</value>
            public bool IsAdd => this == Add;

            /// <summary>
            /// Gets a value indicating whether the Type is and.
            /// </summary>
            /// <value>A value indicating whether the Type is and.</value>
            public bool IsAnd => this == And;

            /// <summary>
            /// Gets a value indicating whether the Type is divide.
            /// </summary>
            /// <value>A value indicating whether the Type is divide.</value>
            public bool IsDivide => this == Divide;

            /// <summary>
            /// Gets a value indicating whether the Type is left.
            /// </summary>
            /// <value>A value indicating whether the Type is left.</value>
            public bool IsLeft => this == Left;

            /// <summary>
            /// Gets a value indicating whether the Type is modulus.
            /// </summary>
            /// <value>A value indicating whether the Type is modulus.</value>
            public bool IsModulus => this == Modulus;

            /// <summary>
            /// Gets a value indicating whether the Type is multiply.
            /// </summary>
            /// <value>A value indicating whether the Type is multiply.</value>
            public bool IsMultiply => this == Multiply;

            /// <summary>
            /// Gets a value indicating whether the Type is or.
            /// </summary>
            /// <value>A value indicating whether the Type is or.</value>
            public bool IsOr => this == Or;

            /// <summary>
            /// Gets a value indicating whether the Type is right.
            /// </summary>
            /// <value>A value indicating whether the Type is right.</value>
            public bool IsRight => this == Right;

            /// <summary>
            /// Gets a value indicating whether the Type is subtract.
            /// </summary>
            /// <value>A value indicating whether the Type is subtract.</value>
            public bool IsSubtract => this == Subtract;

            /// <summary>
            /// Gets a value indicating whether the Type is unspecified.
            /// </summary>
            /// <value>A value indicating whether the Type is unspecified.</value>
            public bool IsUnspecified => this == Unspecified;

            /// <summary>
            /// Gets a value indicating whether the Type is xor.
            /// </summary>
            /// <value>A value indicating whether the Type is xor.</value>
            public bool IsXOR => this == XOR;

            /// <summary>
            /// Defines the < operator for the Type.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator <(Type left, Type right)
            {
                if (left is null)
                {
                    return right is object;
                }

                return left.CompareTo(right) < 0;
            }

            /// <summary>
            /// Defines the > operator for the Type.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator >(Type left, Type right)
            {
                if (left is null)
                {
                    return false;
                }

                return left.CompareTo(right) > 0;
            }

            /// <summary>
            /// Defines the <= operator for the Type.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator <=(Type left, Type right)
            {
                return !(left > right);
            }

            /// <summary>
            /// Defines the >= operator for the Type.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator >=(Type left, Type right)
            {
                return !(left < right);
            }

            /// <summary>
            /// Compares this Type to another instance.
            /// </summary>
            /// <param name="other">The other.</param>
            /// <returns>A signed integer indicating relative order.</returns>
            public int CompareTo(Type other)
            {
                return other is null
                    ? 1
                    : string.CompareOrdinal(_value, other._value);
            }

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