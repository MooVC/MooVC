namespace MooVC.Syntax.CSharp
{
    using System.Diagnostics;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# record declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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

        /// <summary>
        /// Merges the specified attribute, body, and signature snippets into a single snippet using the provided
        /// options.
        /// </summary>
        /// <param name="attributes">The snippet containing attribute information to be prepended to the merged result.</param>
        /// <param name="body">The main body snippet to be merged.</param>
        /// <param name="options">The options that control how the snippets are merged.</param>
        /// <param name="signature">The snippet representing the signature to be included in the merged result.</param>
        /// <returns>A new snippet that combines the attributes, body, and signature according to the specified options.</returns>
        protected override Snippet Merge(Snippet attributes, Snippet body, Options options, Snippet signature)
        {
            if (body.IsEmpty)
            {
                return signature
                    .Append(';')
                    .Prepend(options, attributes);
            }

            return base.Merge(attributes, body, options, signature);
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Record)} {{ " +
                $"{nameof(Attributes)} = `{DebuggerDisplayFormatter.Format(Attributes)}`, " +
                $"{nameof(Constructors)} = `{DebuggerDisplayFormatter.Format(Constructors)}`, " +
                $"{nameof(Declaration)} = `{DebuggerDisplayFormatter.Format(Declaration)}`, " +
                $"{nameof(Events)} = `{DebuggerDisplayFormatter.Format(Events)}`, " +
                $"{nameof(Extensibility)} = `{DebuggerDisplayFormatter.Format(Extensibility)}`, " +
                $"{nameof(Fields)} = `{DebuggerDisplayFormatter.Format(Fields)}`, " +
                $"{nameof(Indexers)} = `{DebuggerDisplayFormatter.Format(Indexers)}`, " +
                $"{nameof(Interfaces)} = `{DebuggerDisplayFormatter.Format(Interfaces)}`, " +
                $"{nameof(IsPartial)} = `{DebuggerDisplayFormatter.Format(IsPartial)}`, " +
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