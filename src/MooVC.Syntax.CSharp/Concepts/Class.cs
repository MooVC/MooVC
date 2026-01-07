namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a C# type syntax class.
    /// </summary>
    [AutoInitiateWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Class
        : Reference
    {
        /// <summary>
        /// Gets the undefined instance.
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
        /// <value>A value indicating whether the Class is static.</value>
        public bool IsStatic { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Class is undefined.
        /// </summary>
        /// <value>A value indicating whether the Class is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Performs the get signature operation for the C# type syntax.
        /// </summary>
        /// <param name="extensibility">The extensibility.</param>
        /// <param name="partial">The partial.</param>
        /// <param name="name">The name.</param>
        /// <param name="scope">The scope.</param>
        /// <returns>The string.</returns>
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