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

    [Fluentify]
    [Valuify]
    public sealed partial class TaskOutput
        : IValidatableObject
    {
        public static readonly TaskOutput Undefined = new TaskOutput();

        internal TaskOutput()
        {
        }

        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        [Descriptor("ForItem")]
        public Identifier ItemName { get; internal set; } = Identifier.Unnamed;

        [Descriptor("ForProperty")]
        public Identifier PropertyName { get; internal set; } = Identifier.Unnamed;

        public Identifier TaskParameter { get; internal set; } = Identifier.Unnamed;

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

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragments().Merge();
        }

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