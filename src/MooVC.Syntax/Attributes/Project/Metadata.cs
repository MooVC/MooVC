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
    /// Represents a MSBuild project attribute metadata.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Metadata
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Metadata Undefined = new Metadata();

        /// <summary>
        /// Initializes a new instance of the Metadata class.
        /// </summary>
        internal Metadata()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the Metadata.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Metadata is undefined.
        /// </summary>
        /// <value>A value indicating whether the Metadata is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Metadata.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the value on the Metadata.
        /// </summary>
        /// <value>The value.</value>
        public Snippet Value { get; internal set; } = Snippet.Empty;

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

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                Name.ToXmlElementName(),
                Condition.ToXmlAttribute(nameof(Condition)),
                Value.ToString()));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Metadata.
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
        /// Validates the Metadata.
        /// </summary>
        /// <remarks>Required members include: Condition, Name.</remarks>
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
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }
    }
}