namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    public partial class Unary
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Type
        {
            public static readonly Type Complement = "~";
            public static readonly Type Decrement = "--";
            public static readonly Type False = "false";
            public static readonly Type Increment = "++";
            public static readonly Type Minus = "-";
            public static readonly Type Not = "!";
            public static readonly Type Plus = "+";
            public static readonly Type True = "true";
            public static readonly Type Unspecified = string.Empty;

            private Type(string value)
            {
                _value = value;
            }

            public bool IsComplement => this == Complement;

            public bool IsDecrement => this == Decrement;

            public bool IsFalse => this == False;

            public bool IsIncrement => this == Increment;

            public bool IsMinus => this == Minus;

            public bool IsNot => this == Not;

            public bool IsPlus => this == Plus;

            public bool IsTrue => this == True;

            public bool IsUnspecified => this == Unspecified;

            public override string ToString()
            {
                return _value;
            }
        }
    }
}