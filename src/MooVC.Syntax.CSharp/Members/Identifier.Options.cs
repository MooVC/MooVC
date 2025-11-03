namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;

    partial class Identifier
    {
        [Fluentify]
        public sealed class Options
        {
            public static readonly Options Default = new Options();

            public Casing Casing { get; set; } = Casing.Camel;

            public bool UseUnderscores { get; set; }
        }
    }
}