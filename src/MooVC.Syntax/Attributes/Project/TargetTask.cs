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
    /// Represents a msbuild project attribute target task.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class TargetTask
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the TargetTask.
        /// </summary>
        public static readonly TargetTask Undefined = new TargetTask();

        /// <summary>
        /// Initializes a new instance of the TargetTask class.
        /// </summary>
        internal TargetTask()
        {
        }

        /// <summary>
        /// Gets or sets the condition on the TargetTask.
        /// </summary>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the continue on error on the TargetTask.
        /// </summary>
        public Options ContinueOnError { get; internal set; } = Options.ErrorAndStop;

        /// <summary>
        /// Gets a value indicating whether the TargetTask is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the TargetTask.
        /// </summary>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the outputs on the TargetTask.
        /// </summary>
        public ImmutableArray<TaskOutput> Outputs { get; internal set; } = ImmutableArray<TaskOutput>.Empty;

        /// <summary>
        /// Gets or sets the parameters on the TargetTask.
        /// </summary>
        public ImmutableArray<TaskParameter> Parameters { get; internal set; } = ImmutableArray<TaskParameter>.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
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

        /// <summary>
        /// Returns the string representation of the TargetTask.
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
        /// Validates the TargetTask and returns validation results.
        /// </summary>
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