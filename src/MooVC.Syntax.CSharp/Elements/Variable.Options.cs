namespace MooVC.Syntax.CSharp.Elements
{
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    partial class Variable
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Camel = new Options();
            public static readonly Options Pascal = new Options { Casing = Identifier.Casing.Pascal };

            public Identifier.Casing Casing { get; set; } = Identifier.Casing.Camel;

            [Ignore]
            public bool IsCamel => Casing == Identifier.Casing.Pascal;

            [Ignore]
            public bool IsPascal => Casing == Identifier.Casing.Pascal;

            public bool UseUnderscore { get; set; }

            public static implicit operator Identifier.Options(Options options)
            {
                Guard.Against.Conversion<Options, Identifier.Options>(options);

                return new Identifier.Options
                {
                    Casing = options.Casing,
                };
            }
        }
    }
}