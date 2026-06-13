namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# class declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Class)} {{ " +
                $"{nameof(Attributes)} = `{DebuggerDisplayFormatter.Format(Attributes)}`, " +
                $"{nameof(Constructors)} = `{DebuggerDisplayFormatter.Format(Constructors)}`, " +
                $"{nameof(Declaration)} = `{DebuggerDisplayFormatter.Format(Declaration)}`, " +
                $"{nameof(Events)} = `{DebuggerDisplayFormatter.Format(Events)}`, " +
                $"{nameof(Extensibility)} = `{DebuggerDisplayFormatter.Format(Extensibility)}`, " +
                $"{nameof(Fields)} = `{DebuggerDisplayFormatter.Format(Fields)}`, " +
                $"{nameof(Indexers)} = `{DebuggerDisplayFormatter.Format(Indexers)}`, " +
                $"{nameof(Interfaces)} = `{DebuggerDisplayFormatter.Format(Interfaces)}`, " +
                $"{nameof(IsPartial)} = `{DebuggerDisplayFormatter.Format(IsPartial)}`, " +
                $"{nameof(IsStatic)} = `{DebuggerDisplayFormatter.Format(IsStatic)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Methods)} = `{DebuggerDisplayFormatter.Format(Methods)}`, " +
                $"{nameof(Operators)} = `{DebuggerDisplayFormatter.Format(Operators)}`, " +
                $"{nameof(Parameters)} = `{DebuggerDisplayFormatter.Format(Parameters)}`, " +
                $"{nameof(Properties)} = `{DebuggerDisplayFormatter.Format(Properties)}`, " +
                $"{nameof(Scope)} = `{DebuggerDisplayFormatter.Format(Scope)}`, " +
                $"{nameof(Types)} = `{DebuggerDisplayFormatter.Format(Types)}` }}";
        }
    }
}