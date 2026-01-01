namespace MooVC.Syntax.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a msbuild project attribute import.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Import
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Import.
        /// </summary>
        public static readonly Import Undefined = new Import();

        /// <summary>
        /// Initializes a new instance of the Import class.
        /// </summary>
        internal Import()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the Import.
        /// </summary>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Import is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the label on the Import.
        /// </summary>
        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the project on the Import.
        /// </summary>
        [Descriptor("ForProject")]
        public Snippet Project { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the sdk on the Import.
        /// </summary>
        public Snippet Sdk { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Import),
                Project.ToXmlAttribute(nameof(Project)),
                Sdk.ToXmlAttribute(nameof(Sdk)),
                Condition.ToXmlAttribute(nameof(Condition)),
                Label.ToXmlAttribute(nameof(Label))));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Import.
        /// </summary>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Import and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Condition), _ => !Condition.IsMultiLine, Condition)
                .And(nameof(Label), _ => !Label.IsMultiLine, Label)
                .And(nameof(Project), _ => Project.IsSingleLine, Project)
                .And(nameof(Sdk), _ => !Sdk.IsMultiLine, Sdk)
                .Results;
        }
    }
}