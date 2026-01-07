namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a C# type syntax record.
    /// </summary>
    [AutoInitiateWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Record
        : Reference
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Record Undefined = new Record();

        /// <summary>
        /// Initializes a new instance of the Record class.
        /// </summary>
        public Record()
            : base(Parameter.Options.Pascal, "record")
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Record is undefined.
        /// </summary>
        /// <value>A value indicating whether the Record is undefined.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;
    }
}