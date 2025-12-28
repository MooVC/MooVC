namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Sdk
        : IValidatableObject
    {
        public static readonly Sdk Unspecified = new Sdk();

        internal Sdk()
        {
        }

        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        public Snippet MinimumVersion { get; internal set; } = Snippet.Empty;

        public Qualifier Name { get; internal set; } = Qualifier.Unqualified;

        public Snippet Version { get; internal set; } = Snippet.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnqualified, Name)
                .Results;
        }
    }
}