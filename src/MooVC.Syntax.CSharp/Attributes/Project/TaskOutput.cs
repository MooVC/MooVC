namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
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

        public Snippet Condition { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier ItemName { get; internal set; } = Identifier.Unnamed;

        public Identifier PropertyName { get; internal set; } = Identifier.Unnamed;

        public Identifier TaskParameter { get; internal set; } = Identifier.Unnamed;

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

        public XElement ToFragment()
        {
            return new XElement(
                "Output",
                Condition.ToXmlAttribute(nameof(Condition)),
                ItemName.ToXmlAttribute(nameof(ItemName)),
                PropertyName.ToXmlAttribute(nameof(PropertyName)),
                TaskParameter.ToXmlAttribute(nameof(TaskParameter)));
        }

        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            return ToFragment().ToString();
        }
    }
}