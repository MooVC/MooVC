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
    public sealed partial class TaskOutput
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly TaskOutput Undefined = new TaskOutput();

        /// <summary>
        /// Initializes a new instance of the TaskOutput class.
        /// </summary>
        internal TaskOutput()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the TaskOutput.
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
        /// Gets or sets the item name on the TaskOutput.
        /// </summary>
        /// <value>The item name.</value>
        [Descriptor("ForItem")]
        public Identifier ItemName { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the property name on the TaskOutput.
        /// </summary>
        /// <value>The property name.</value>
        [Descriptor("ForProperty")]
        public Identifier PropertyName { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the task parameter on the TaskOutput.
        /// </summary>
        /// <value>The task parameter.</value>
        public Identifier TaskParameter { get; internal set; } = Identifier.Unnamed;

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
                "Output",
                Condition.ToXmlAttribute(nameof(Condition)),
                ItemName.ToXmlAttribute(nameof(ItemName)),
                PropertyName.ToXmlAttribute(nameof(PropertyName)),
                TaskParameter.ToXmlAttribute(nameof(TaskParameter))));

            return builder.ToImmutable();
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