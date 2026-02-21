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
    /// Represents a MSBuild project attribute import.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Import
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Import Undefined = new Import();

        /// <summary>
        /// Initializes a new instance of the Import class.
        /// </summary>
        internal Import()
        {
        }

        /// <summary>
        /// Gets the condition on the Import.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Import is undefined.
        /// </summary>
        /// <value>A value indicating whether the Import is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the label on the Import.
        /// </summary>
        /// <value>The label.</value>
        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the project on the Import.
        /// </summary>
        /// <value>The project.</value>
        [Descriptor("ForProject")]
        public Snippet Project { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the sdk on the Import.
        /// </summary>
        /// <value>The sdk.</value>
        public Snippet Sdk { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Performs the to fragments operation for the MSBuild project attribute.
        /// </summary>
        /// <returns>The immutable array x element.</returns>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            return ImmutableArray.Create(new XElement(
                nameof(Import),
                Project.ToXmlAttribute(nameof(Project)),
                Sdk.ToXmlAttribute(nameof(Sdk)),
                Condition.ToXmlAttribute(nameof(Condition)),
                Label.ToXmlAttribute(nameof(Label))));
        }

        /// <summary>
        /// Returns the string representation of the Import.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

        /// <summary>
        /// Validates the Import.
        /// </summary>
        /// <remarks>Required members include: Condition, Label, Project, Sdk.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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