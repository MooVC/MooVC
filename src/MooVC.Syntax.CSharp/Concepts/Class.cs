namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Parameter = MooVC.Syntax.CSharp.Members.Parameter;

    [Fluentify]
    [Valuify]
    public sealed partial class Class
        : Reference
    {
        public static readonly Class Undefined = new Class();

        internal Class()
            : base(Parameter.Options.Camel, "class")
        {
        }

        public override bool IsUndefined => this == Undefined;
    }
}