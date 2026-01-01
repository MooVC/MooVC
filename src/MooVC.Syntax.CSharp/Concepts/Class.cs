namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    [Fluentify]
    [Valuify]
    public sealed partial class Class
        : Reference
    {
        public static readonly Class Undefined = new Class();

        public Class()
            : base(Parameter.Options.Camel, "class")
        {
        }

        public bool IsStatic { get; internal set; }

        [Ignore]
        public override bool IsUndefined => this == Undefined;

        protected override string GetSignature(string extensibility, string partial, string name, string scope)
        {
            if (IsStatic)
            {
                extensibility = "static";
            }

            return base.GetSignature(extensibility, partial, name, scope);
        }
    }
}