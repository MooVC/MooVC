namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Fluentify;
    using Monify;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class New
    {
        public static readonly New Required = "new()";
        public static readonly New NotRequired = string.Empty;

        internal New(string value)
        {
            _value = value;
        }

        public bool IsRequired => this == Required;

        public bool IsNotRequired => this == NotRequired;

        public static implicit operator string(New @new)
        {
            if (@new is null)
            {
                @new = NotRequired;
            }

            return @new.ToString();
        }

        public static implicit operator Snippet(New @new)
        {
            return Snippet.From(@new);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}