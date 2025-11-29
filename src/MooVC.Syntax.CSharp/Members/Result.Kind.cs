namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using Monify;

    public partial class Result
    {
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Kind
        {
            public static readonly Kind None = string.Empty;
            public static readonly Kind Ref = "ref";
            public static readonly Kind RefReadOnly = "ref readonly";
            public static readonly Kind Unsafe = "unsafe";

            internal Kind(string value)
            {
                _value = value;
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}