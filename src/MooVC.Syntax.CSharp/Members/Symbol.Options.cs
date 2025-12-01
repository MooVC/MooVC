namespace MooVC.Syntax.CSharp.Members
{
    using Fluentify;
    using Valuify;

    public partial class Symbol
    {
        [Fluentify]
        [Valuify]
        public sealed partial class Options
        {
            public static readonly Options Default = new Options();

            public Qualification Qualification { get; set; } = Qualification.Minimum;
        }
    }
}