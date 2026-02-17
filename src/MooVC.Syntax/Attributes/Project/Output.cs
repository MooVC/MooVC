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
    /// Represents a MSBuild project attribute task output.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Output
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Output Undefined = new Output();

        /// <summary>
        /// Initializes a new instance of the TaskOutput class.
        /// </summary>
        internal Output()
        {
        }

        /// <summary>
        /// Gets the condition on the TaskOutput.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the TaskOutput is undefined.
        /// </summary>
        /// <value>A value indicating whether the TaskOutput is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the item name on the TaskOutput.
        /// </summary>
        /// <value>The item name.</value>
        [Descriptor("ForItem")]
        public Name ItemName { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the property name on the TaskOutput.
        /// </summary>
        /// <value>The property name.</value>
        [Descriptor("ForProperty")]
        public Name PropertyName { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the task parameter on the TaskOutput.
        /// </summary>
        /// <value>The task parameter.</value>
        public Name TaskParameter { get; internal set; } = Name.Unnamed;

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
                nameof(Output),
                Condition.ToXmlAttribute(nameof(Condition))
                .And(ItemName.ToXmlAttribute(nameof(ItemName)))
                .And(PropertyName.ToXmlAttribute(nameof(PropertyName)))
                .And(TaskParameter.ToXmlAttribute(nameof(TaskParameter)))));
        }

        /// <summary>
        /// Returns the string representation of the TaskOutput.
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
        /// Validates the TaskOutput.
        /// </summary>
        /// <remarks>Required members include: Condition, ItemName, PropertyName, TaskParameter.</remarks>
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
                .AndIf(!PropertyName.IsUnnamed, nameof(ItemName), _ => !ItemName.IsUnnamed, ItemName)
                .AndIf(!ItemName.IsUnnamed, nameof(PropertyName), _ => !PropertyName.IsUnnamed, PropertyName)
                .AndIf(!PropertyName.IsUnnamed, nameof(PropertyName), PropertyName)
                .AndIf(!TaskParameter.IsUnnamed, nameof(TaskParameter), TaskParameter)
                .Results;
        }
    }
}