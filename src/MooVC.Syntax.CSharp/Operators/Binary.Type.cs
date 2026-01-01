namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    /// <summary>
    /// Represents a c# operator syntax binary.
    /// </summary>
    public partial class Binary
    {
        /// <summary>
        /// Represents a c# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Type
            : IComparable<Type>
        {
            /// <summary>
            /// Gets the add on the Type.
            /// </summary>
            public static readonly Type Add = "+";
            /// <summary>
            /// Gets the and on the Type.
            /// </summary>
            public static readonly Type And = "&";
            /// <summary>
            /// Gets the divide on the Type.
            /// </summary>
            public static readonly Type Divide = "/";
            /// <summary>
            /// Gets the left on the Type.
            /// </summary>
            public static readonly Type Left = "<<";
            /// <summary>
            /// Gets the modulus on the Type.
            /// </summary>
            public static readonly Type Modulus = "%";
            /// <summary>
            /// Gets the multiply on the Type.
            /// </summary>
            public static readonly Type Multiply = "*";
            /// <summary>
            /// Gets the or on the Type.
            /// </summary>
            public static readonly Type Or = "|";
            /// <summary>
            /// Gets the right on the Type.
            /// </summary>
            public static readonly Type Right = ">>";
            /// <summary>
            /// Gets the subtract on the Type.
            /// </summary>
            public static readonly Type Subtract = "-";
            /// <summary>
            /// Gets the unspecified on the Type.
            /// </summary>
            public static readonly Type Unspecified = string.Empty;
            /// <summary>
            /// Gets the xor on the Type.
            /// </summary>
            public static readonly Type XOR = "^";

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is add.
            /// </summary>
            public bool IsAdd => this == Add;

            /// <summary>
            /// Gets a value indicating whether the Type is and.
            /// </summary>
            public bool IsAnd => this == And;

            /// <summary>
            /// Gets a value indicating whether the Type is divide.
            /// </summary>
            public bool IsDivide => this == Divide;

            /// <summary>
            /// Gets a value indicating whether the Type is left.
            /// </summary>
            public bool IsLeft => this == Left;

            /// <summary>
            /// Gets a value indicating whether the Type is modulus.
            /// </summary>
            public bool IsModulus => this == Modulus;

            /// <summary>
            /// Gets a value indicating whether the Type is multiply.
            /// </summary>
            public bool IsMultiply => this == Multiply;

            /// <summary>
            /// Gets a value indicating whether the Type is or.
            /// </summary>
            public bool IsOr => this == Or;

            /// <summary>
            /// Gets a value indicating whether the Type is right.
            /// </summary>
            public bool IsRight => this == Right;

            /// <summary>
            /// Gets a value indicating whether the Type is subtract.
            /// </summary>
            public bool IsSubtract => this == Subtract;

            /// <summary>
            /// Gets a value indicating whether the Type is unspecified.
            /// </summary>
            public bool IsUnspecified => this == Unspecified;

            /// <summary>
            /// Gets a value indicating whether the Type is xor.
            /// </summary>
            public bool IsXOR => this == XOR;

            /// <summary>
            /// Defines the < operator for the Type.
            /// </summary>
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
            public static bool operator <=(Type left, Type right)
            {
                return !(left > right);
            }

            /// <summary>
            /// Defines the >= operator for the Type.
            /// </summary>
            public static bool operator >=(Type left, Type right)
            {
                return !(left < right);
            }

            /// <summary>
            /// Compares this Type to another instance.
            /// </summary>
            public int CompareTo(Type other)
            {
                return other is null
                    ? 1
                    : string.CompareOrdinal(_value, other._value);
            }

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