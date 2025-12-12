namespace MooVC.Syntax.CSharp.Members
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;

    public partial class Argument
    {
        [Monify(Type = typeof(string))]
        [SkipAutoInstantiation]
        public sealed partial class Formatter
        {
            public static readonly Formatter Call = new Formatter("{0}: {1}");
            public static readonly Formatter Declaration = new Formatter("{0} = {1}");

            internal Formatter(string value)
            {
                _value = value;
            }

            public bool IsCall => this == Call;

            public bool IsDeclaration => this == Declaration;

            public static implicit operator string(Formatter formatter)
            {
                Guard.Against.Conversion<Formatter, string>(formatter);

                return formatter.ToString();
            }

            public static implicit operator Snippet(Formatter formatter)
            {
                Guard.Against.Conversion<Formatter, Snippet>(formatter);

                return Snippet.From(formatter);
            }

            public override string ToString()
            {
                return _value;
            }
        }
    }
}