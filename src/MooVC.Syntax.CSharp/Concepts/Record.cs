namespace MooVC.Syntax.CSharp.Concepts
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;
    using Parameter = MooVC.Syntax.CSharp.Elements.Parameter;

    /// <summary>
    /// Represents a c# type syntax record.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Record
        : Reference
    {
        /// <summary>
        /// Gets the undefined on the Record.
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
        [Ignore]
        public override bool IsUndefined => this == Undefined;
    }
}