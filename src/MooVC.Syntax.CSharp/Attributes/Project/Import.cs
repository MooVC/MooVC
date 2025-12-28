namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Import
        : IValidatableObject
    {
        public static readonly Import Undefined = new Import();

        internal Import()
        {
        }

        public Snippet Condition { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Snippet Label { get; internal set; } = Snippet.Empty;

        public Snippet Project { get; internal set; } = Snippet.Empty;

        public Snippet Sdk { get; internal set; } = Snippet.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return Enumerable.Empty<ValidationResult>();
        }
    }
}