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
    public sealed partial class TargetTask
        : IValidatableObject
    {
        public static readonly TargetTask Undefined = new TargetTask();

        internal TargetTask()
        {
        }

        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        public Options ContinueOnError { get; internal set; } = Options.ErrorAndStop;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public ImmutableArray<TaskOutput> Outputs { get; internal set; } = ImmutableArray<TaskOutput>.Empty;

        public ImmutableArray<TaskParameter> Parameters { get; internal set; } = ImmutableArray<TaskParameter>.Empty;

        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XAttribute[] attributes = Parameters
                .Where(parameter => !parameter.IsUndefined)
                .Select(parameter => new XAttribute(parameter.Name.ToXmlElementName(), parameter.Value.ToString()))
                .ToArray();

            XElement[] outputs = Outputs
                .Where(output => !output.IsUndefined)
                .SelectMany(output => output.ToFragments())
                .ToArray();

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                Name.ToXmlElementName(),
                Condition.ToXmlAttribute(nameof(Condition)),
                ContinueOnError.ToXmlAttribute(),
                attributes,
                outputs));

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
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .AndIf(!Outputs.IsDefaultOrEmpty, nameof(Outputs), output => !output.IsUndefined, Outputs)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .Results;
        }
    }
}