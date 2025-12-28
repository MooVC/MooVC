namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    [Fluentify]
    [Valuify]
    public sealed partial class Record
        : Reference
    {
        public static readonly Record Undefined = new Record();

        internal Record()
            : base(Parameter.Options.Pascal, "record")
        {
        }

        [Ignore]
        public override bool IsUndefined => this == Undefined;
    }
}