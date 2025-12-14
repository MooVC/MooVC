namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    public partial class Binary
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Type
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

            public override string ToString()
            {
                return _value;
            }
        }
    }
}