namespace MooVC.Syntax.Elements
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    partial class Identifier
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Camel = new Options();
            public static readonly Options Pascal = new Options { Casing = Casing.Pascal };

            public Casing Casing { get; set; } = Casing.Camel;

            [Ignore]
            public bool IsCamel => Casing == Casing.Pascal;

            [Ignore]
            public bool IsPascal => Casing == Casing.Pascal;
        }
    }
}