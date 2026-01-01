namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    public partial class Attribute
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Specifier
        {
            public static readonly Specifier Assembly = "assembly";
            public static readonly Specifier Class = "class";
            public static readonly Specifier Constructor = "constructor";
            public static readonly Specifier Delegate = "delegate";
            public static readonly Specifier Enum = "enum";
            public static readonly Specifier Event = "event";
            public static readonly Specifier Field = "field";
            public static readonly Specifier Interface = "interface";
            public static readonly Specifier Method = "method";
            public static readonly Specifier Module = "module";
            public static readonly Specifier None = string.Empty;
            public static readonly Specifier Param = "param";
            public static readonly Specifier Property = "property";
            public static readonly Specifier Record = "record";
            public static readonly Specifier Return = "return";
            public static readonly Specifier Struct = "struct";
            public static readonly Specifier Type = "type";
            public static readonly Specifier Typevar = "typevar";

            private Specifier(string value)
            {
                _value = value;
            }

            public static implicit operator string(Specifier specifier)
            {
                Guard.Against.Conversion<Specifier, string>(specifier);

                return specifier.ToString();
            }

            public static implicit operator Snippet(Specifier specifier)
            {
                Guard.Against.Conversion<Specifier, Snippet>(specifier);

                return Snippet.From(specifier);
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}