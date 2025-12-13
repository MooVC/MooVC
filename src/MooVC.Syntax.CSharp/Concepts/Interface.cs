namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Interface
        : Construct
    {
        public static readonly Interface Undefined = new Interface();

        internal Interface()
        {
        }

        [Ignore]
        public override bool IsUndefined => this == Undefined;

        protected override Snippet ToSnippet(Snippet.Options options)
        {
            throw new System.NotImplementedException();
        }
    }
}