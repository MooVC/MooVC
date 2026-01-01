namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    /// <summary>
    /// Represents a c# operator syntax comparison.
    /// </summary>
    public partial class Comparison
    {
        /// <summary>
        /// Represents a c# operator syntax type.
        /// </summary>
        [Monify(Type = typeof(string))]
        public sealed partial class Type
            : IComparable<Type>
        {
            /// <summary>
            /// Gets the equality on the Type.
            /// </summary>
            public static readonly Type Equality = "==";
            /// <summary>
            /// Gets the greater than on the Type.
            /// </summary>
            public static readonly Type GreaterThan = ">";
            /// <summary>
            /// Gets the greater than or equal on the Type.
            /// </summary>
            public static readonly Type GreaterThanOrEqual = ">=";
            /// <summary>
            /// Gets the inequality on the Type.
            /// </summary>
            public static readonly Type Inequality = "!=";
            /// <summary>
            /// Gets the less than on the Type.
            /// </summary>
            public static readonly Type LessThan = "<";
            /// <summary>
            /// Gets the less than or equal on the Type.
            /// </summary>
            public static readonly Type LessThanOrEqual = "<=";
            /// <summary>
            /// Gets the unspecified on the Type.
            /// </summary>
            public static readonly Type Unspecified = string.Empty;

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is equality.
            /// </summary>
            public bool IsEquality => this == Equality;

            /// <summary>
            /// Gets a value indicating whether the Type is greater than.
            /// </summary>
            public bool IsGreaterThan => this == GreaterThan;

            /// <summary>
            /// Gets a value indicating whether the Type is greater than or equal.
            /// </summary>
            public bool IsGreaterThanOrEqual => this == GreaterThanOrEqual;

            /// <summary>
            /// Gets a value indicating whether the Type is inequality.
            /// </summary>
            public bool IsInequality => this == Inequality;

            /// <summary>
            /// Gets a value indicating whether the Type is less than.
            /// </summary>
            public bool IsLessThan => this == LessThan;

            /// <summary>
            /// Gets a value indicating whether the Type is less than or equal.
            /// </summary>
            public bool IsLessThanOrEqual => this == LessThanOrEqual;

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