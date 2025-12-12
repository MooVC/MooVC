namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Property
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Setter
        {
            public static readonly Setter Default = new Setter();

            public Snippet Behaviour { get; set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Mode Mode { get; set; } = Mode.Set;

            public Scope Scope { get; set; }
        }
    }
}