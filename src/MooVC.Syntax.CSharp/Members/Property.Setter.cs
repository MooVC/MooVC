namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    public partial class Property
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Setter
        {
            public static readonly Setter Default = new Setter();

            internal Setter()
            {
            }

            public Snippet Behaviour { get; internal set; } = Snippet.Empty;

            [Ignore]
            public bool IsDefault => this == Default;

            public Mode Mode { get; internal set; } = Mode.Set;

            public Scope Scope { get; internal set; } = Scope.Unspecified;
        }
    }
}