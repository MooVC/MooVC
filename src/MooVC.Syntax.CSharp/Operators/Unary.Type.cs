namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a C# operator syntax unary.
    /// </summary>
    public partial class Unary
    {
        /// <summary>
        /// Represents a C# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        [SkipAutoInitialization]
        public sealed partial class Type
            : IComparable<Type>
        {
            /// <summary>
            /// Represents the complement for the Type.
            /// </summary>
            public static readonly Type Complement = "~";

            /// <summary>
            /// Represents the decrement for the Type.
            /// </summary>
            public static readonly Type Decrement = "--";

            /// <summary>
            /// Represents the false for the Type.
            /// </summary>
            public static readonly Type False = "false";

            /// <summary>
            /// Represents the increment for the Type.
            /// </summary>
            public static readonly Type Increment = "++";

            /// <summary>
            /// Represents the minus for the Type.
            /// </summary>
            public static readonly Type Minus = "-";

            /// <summary>
            /// Represents the not for the Type.
            /// </summary>
            public static readonly Type Not = "!";

            /// <summary>
            /// Represents the plus for the Type.
            /// </summary>
            public static readonly Type Plus = "+";

            /// <summary>
            /// Represents the true for the Type.
            /// </summary>
            public static readonly Type True = "true";

            /// <summary>
            /// Gets the unspecified instance.
            /// </summary>
            public static readonly Type Unspecified = string.Empty;

            private Type(string value)
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
            /// Gets a value indicating whether the Type is false.
            /// </summary>
            /// <value>A value indicating whether the Type is false.</value>
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
            /// Gets a value indicating whether the Type is true.
            /// </summary>
            /// <value>A value indicating whether the Type is true.</value>
            public bool IsTrue => this == True;

            /// <summary>
            /// Gets a value indicating whether the Type is unspecified.
            /// </summary>
            /// <value>A value indicating whether the Type is unspecified.</value>
            public bool IsUnspecified => this == Unspecified;

            /// <summary>
            /// Defines the less than operator for the Type.
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
            /// Defines the greater than operator for the Type.
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
            /// Defines the less than or equal to operator for the Type.
            /// </summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The .</returns>
            public static bool operator <=(Type left, Type right)
            {
                return !(left > right);
            }

            /// <summary>
            /// Defines the greater than or equal to operator for the Type.
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