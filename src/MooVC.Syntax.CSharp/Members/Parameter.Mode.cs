namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;

    public partial class Parameter
    {
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
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

            public bool IsIn => this == In;

            public bool IsOut => this == Out;

            public bool IsNone => this == None;

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