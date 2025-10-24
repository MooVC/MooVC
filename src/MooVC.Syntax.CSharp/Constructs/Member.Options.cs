namespace MooVC.Syntax.CSharp.Constructs
{
    using Fluentify;

    partial class Member
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