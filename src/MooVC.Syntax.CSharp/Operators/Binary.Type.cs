namespace MooVC.Syntax.CSharp.Operators
{
    using System;
    using Monify;

    public partial class Binary
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Type
            : IComparable<Type>
        {
            public static readonly Type Add = "+";
            public static readonly Type And = "&";
            public static readonly Type Divide = "/";
            public static readonly Type Left = "<<";
            public static readonly Type Modulus = "%";
            public static readonly Type Multiply = "*";
            public static readonly Type Or = "|";
            public static readonly Type Right = ">>";
            public static readonly Type Subtract = "-";
            public static readonly Type Unspecified = string.Empty;
            public static readonly Type XOR = "^";

            private Type(string value)
            {
                _value = value;
            }

            public bool IsAdd => this == Add;

            public bool IsAnd => this == And;

            public bool IsDivide => this == Divide;

            public bool IsLeft => this == Left;

            public bool IsModulus => this == Modulus;

            public bool IsMultiply => this == Multiply;

            public bool IsOr => this == Or;

            public bool IsRight => this == Right;

            public bool IsSubtract => this == Subtract;

            public bool IsUnspecified => this == Unspecified;

            public bool IsXOR => this == XOR;

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