namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Options
    {
        public static readonly Options Default = new Options();

        [Ignore]
        public bool IsDefault => this == Default;

        public Qualifier.Options Namespace { get; internal set; } = Qualifier.Options.File;

        public Snippet.Options Snippets { get; internal set; } = Snippet.Options.Default;
    }
}