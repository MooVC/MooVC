namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Fluentify;
    using Monify;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Nature
    {
        public static readonly Nature Class = "class";
        public static readonly Nature Struct = "struct";
        public static readonly Nature Unmanaged = "unmanaged";
        public static readonly Nature NotNull = "notnull";
        public static readonly Nature Unspecified = string.Empty;

        internal Nature(string value)
        {
            _value = value;
        }

        public bool IsUnspecified => this == Unspecified;

        public override string ToString()
        {
            return _value;
        }
    }
}