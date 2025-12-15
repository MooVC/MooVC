namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    public partial class Comparison
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Type
            : IComparable<Type>
        {
            public static readonly Type Equality = "==";
            public static readonly Type GreaterThan = ">";
            public static readonly Type GreaterThanOrEqual = ">=";
            public static readonly Type Inequality = "!=";
            public static readonly Type LessThan = "<";
            public static readonly Type LessThanOrEqual = "<=";
            public static readonly Type Unspecified = string.Empty;

            private Type(string value)
            {
                _value = value;
            }

            public bool IsEquality => this == Equality;

            public bool IsGreaterThan => this == GreaterThan;

            public bool IsGreaterThanOrEqual => this == GreaterThanOrEqual;

            public bool IsInequality => this == Inequality;

            public bool IsLessThan => this == LessThan;

            public bool IsLessThanOrEqual => this == LessThanOrEqual;

            public bool IsUnspecified => this == Unspecified;

            public static bool operator <(Type left, Type right)
            {
                if (left is null)
                {
                    return right is object;
                }

                return left.CompareTo(right) < 0;
            }

            public static bool operator >(Type left, Type right)
            {
                if (left is null)
                {
                    return false;
                }

                return left.CompareTo(right) > 0;
            }

            public static bool operator <=(Type left, Type right)
            {
                return !(left > right);
            }

            public static bool operator >=(Type left, Type right)
            {
                return !(left < right);
            }

            public int CompareTo(Type other)
            {
                return other is null
                    ? 1
                    : string.CompareOrdinal(_value, other._value);
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}