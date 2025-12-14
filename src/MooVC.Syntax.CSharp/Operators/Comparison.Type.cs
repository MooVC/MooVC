namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    public partial class Comparison
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Type
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

            public override string ToString()
            {
                return _value;
            }
        }
    }
}