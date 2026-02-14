namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Fluentify;
    using Monify;

    /// <summary>
    /// Represents a C# operator syntax comparison.
    /// </summary>
    public partial class Comparison
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
            /// Represents the equality for the Type.
            /// </summary>
            public static readonly Type Equality = "==";

            /// <summary>
            /// Represents the greater than for the Type.
            /// </summary>
            public static readonly Type GreaterThan = ">";

            /// <summary>
            /// Represents the greater than or equal for the Type.
            /// </summary>
            public static readonly Type GreaterThanOrEqual = ">=";

            /// <summary>
            /// Represents the inequality for the Type.
            /// </summary>
            public static readonly Type Inequality = "!=";

            /// <summary>
            /// Represents the less than for the Type.
            /// </summary>
            public static readonly Type LessThan = "<";

            /// <summary>
            /// Represents the less than or equal for the Type.
            /// </summary>
            public static readonly Type LessThanOrEqual = "<=";

            /// <summary>
            /// Gets the unspecified instance.
            /// </summary>
            public static readonly Type Unspecified = string.Empty;

            private Type(string value)
            {
                _value = value;
            }

            /// <summary>
            /// Gets a value indicating whether the Type is equality.
            /// </summary>
            /// <value>A value indicating whether the Type is equality.</value>
            public bool IsEquality => this == Equality;

            /// <summary>
            /// Gets a value indicating whether the Type is greater than.
            /// </summary>
            /// <value>A value indicating whether the Type is greater than.</value>
            public bool IsGreaterThan => this == GreaterThan;

            /// <summary>
            /// Gets a value indicating whether the Type is greater than or equal.
            /// </summary>
            /// <value>A value indicating whether the Type is greater than or equal.</value>
            public bool IsGreaterThanOrEqual => this == GreaterThanOrEqual;

            /// <summary>
            /// Gets a value indicating whether the Type is inequality.
            /// </summary>
            /// <value>A value indicating whether the Type is inequality.</value>
            public bool IsInequality => this == Inequality;

            /// <summary>
            /// Gets a value indicating whether the Type is less than.
            /// </summary>
            /// <value>A value indicating whether the Type is less than.</value>
            public bool IsLessThan => this == LessThan;

            /// <summary>
            /// Gets a value indicating whether the Type is less than or equal.
            /// </summary>
            /// <value>A value indicating whether the Type is less than or equal.</value>
            public bool IsLessThanOrEqual => this == LessThanOrEqual;

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