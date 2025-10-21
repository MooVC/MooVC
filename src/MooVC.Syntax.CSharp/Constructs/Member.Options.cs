namespace MooVC.Syntax.CSharp.Constructs
{
    using Fluentify;

    partial class Member
    {
        [Fluentify]
        public sealed partial class Options
        {
            public static readonly Options Default = new Options();

            public Casing Casing { get; } = Casing.Camel;

            public bool UseUnderscores { get; }
        }
    }
}