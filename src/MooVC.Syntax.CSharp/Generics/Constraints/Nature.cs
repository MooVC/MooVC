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

        public static implicit operator string(Nature nature)
        {
            if (nature is null)
            {
                nature = Unspecified;
            }

            return nature.ToString();
        }

        public static implicit operator Snippet(Nature nature)
        {
            return Snippet.From(nature);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}