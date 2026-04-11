namespace MooVC.Syntax.CSharp
{
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# record declaration model.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
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
    }
}