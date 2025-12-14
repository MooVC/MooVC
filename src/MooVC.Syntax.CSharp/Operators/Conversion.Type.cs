namespace MooVC.Syntax.CSharp.Operators
{
    using Monify;

    public partial class Conversion
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Type
        {
            public static readonly Type Explicit = "explicit";
            public static readonly Type Implicit = "implicit";

            private Type(string value)
            {
                _value = value;
            }

            public bool IsExplicit => this == Explicit;

            public bool IsImplicit => this == Implicit;

            public override string ToString()
            {
                return _value;
            }
        }
    }
}