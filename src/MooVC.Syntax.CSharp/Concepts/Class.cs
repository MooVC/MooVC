namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a c# type syntax class.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Class
        : Reference
    {
        /// <summary>
        /// Gets the undefined on the Class.
        /// </summary>
        public static readonly Class Undefined = new Class();

        /// <summary>
        /// Initializes a new instance of the Class class.
        /// </summary>
        public Class()
            : base(Parameter.Options.Camel, "class")
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Class is static.
        /// </summary>
        public bool IsStatic { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Class is undefined.
        /// </summary>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Performs the Get Signature operation for the c# type syntax.
        /// </summary>
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