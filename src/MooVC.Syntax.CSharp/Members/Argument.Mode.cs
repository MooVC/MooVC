namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Monify;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Argument
    {
        [Monify(Type = typeof(string))]
        public sealed partial class Mode
        {
            public static readonly Mode In = "in";
            public static readonly Mode Out = "out";
            public static readonly Mode None = string.Empty;
            public static readonly Mode Ref = "ref";
            public static readonly Mode RefReadonly = "ref readonly";

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