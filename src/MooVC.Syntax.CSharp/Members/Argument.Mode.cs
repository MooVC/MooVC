namespace MooVC.Syntax.CSharp.Members
{
    using Monify;
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
        }
    }
}