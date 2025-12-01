namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using Ardalis.GuardClauses;
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
            Guard.Against.Conversion<New, string>(@new);

            return @new.ToString();
        }

        public static implicit operator Snippet(New @new)
        {
            Guard.Against.Conversion<New, Snippet>(@new);

            return Snippet.From(@new);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}