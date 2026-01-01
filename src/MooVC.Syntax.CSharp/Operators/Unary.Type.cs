namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    /// <summary>
    /// Represents a c# operator syntax unary.
    /// </summary>
    public partial class Unary
    {
        /// <summary>
        /// Represents a c# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Type
            : IComparable<Type>
        {
            /// <summary>
            /// Gets the complement on the Type.
            /// </summary>
            public static readonly Type Complement = "~";
            /// <summary>
            /// Gets the decrement on the Type.
            /// </summary>
            public static readonly Type Decrement = "--";
            /// <summary>
            /// Gets the false on the Type.
            /// </summary>
            public static readonly Type False = "false";
            /// <summary>
            /// Gets the increment on the Type.
            /// </summary>
            public static readonly Type Increment = "++";
            /// <summary>
            /// Gets the minus on the Type.
            /// </summary>
            public static readonly Type Minus = "-";
            /// <summary>
            /// Gets the not on the Type.
            /// </summary>
            public static readonly Type Not = "!";
            /// <summary>
            /// Gets the plus on the Type.
            /// </summary>
            public static readonly Type Plus = "+";
            /// <summary>
            /// Gets the true on the Type.
            /// </summary>
            public static readonly Type True = "true";
            /// <summary>
            /// Gets the unspecified on the Type.
            /// </summary>
            public static readonly Type Unspecified = string.Empty;

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is complement.
            /// </summary>
            public bool IsComplement => this == Complement;

            /// <summary>
            /// Gets a value indicating whether the Type is decrement.
            /// </summary>
            public bool IsDecrement => this == Decrement;

            /// <summary>
            /// Gets a value indicating whether the Type is false.
            /// </summary>
            public bool IsFalse => this == False;

            /// <summary>
            /// Gets a value indicating whether the Type is increment.
            /// </summary>
            public bool IsIncrement => this == Increment;

            /// <summary>
            /// Gets a value indicating whether the Type is minus.
            /// </summary>
            public bool IsMinus => this == Minus;

            /// <summary>
            /// Gets a value indicating whether the Type is not.
            /// </summary>
            public bool IsNot => this == Not;

            /// <summary>
            /// Gets a value indicating whether the Type is plus.
            /// </summary>
            public bool IsPlus => this == Plus;

            /// <summary>
            /// Gets a value indicating whether the Type is true.
            /// </summary>
            public bool IsTrue => this == True;

            /// <summary>
            /// Gets a value indicating whether the Type is unspecified.
            /// </summary>
            public bool IsUnspecified => this == Unspecified;

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