namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Monify;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Parameter
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Mode
        {
            public static readonly Mode In = "in";
            public static readonly Mode Out = "out";
            public static readonly Mode None = string.Empty;
            public static readonly Mode Ref = "ref";
            public static readonly Mode RefReadonly = "ref readonly";
            public static readonly Mode Scoped = "scoped";
            public static readonly Mode This = "this";

            internal Mode(string value)
            {
                _value = value;
            }

            [Ignore]
            public bool IsIn => this == In;

            [Ignore]
            public bool IsOut => this == Out;

            [Ignore]
            public bool IsNone => this == None;

            [Ignore]
            public bool IsRef => this == Ref;

            [Ignore]
            public bool IsRefReadonly => this == RefReadonly;

            [Ignore]
            public bool IsScoped => this == Scoped;

            [Ignore]
            public bool IsThis => this == This;

            public static implicit operator string(Mode mode)
            {
                Guard.Against.Conversion<Mode, string>(mode);

                return mode.ToString();
            }

            public static implicit operator Snippet(Mode mode)
            {
                Guard.Against.Conversion<Mode, Snippet>(mode);

                return Snippet.From(mode);
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}