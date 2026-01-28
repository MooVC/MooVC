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
    /// Represents a MSBuild project attribute target task.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class TargetTask
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly TargetTask Undefined = new TargetTask();

        /// <summary>
        /// Initializes a new instance of the TargetTask class.
        /// </summary>
        internal TargetTask()
        {
        }

        /// <summary>
        /// Gets the condition on the TargetTask.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the continue on error on the TargetTask.
        /// </summary>
        /// <value>The continue on error.</value>
        public Options ContinueOnError { get; internal set; } = Options.ErrorAndStop;

        /// <summary>
        /// Gets a value indicating whether the TargetTask is undefined.
        /// </summary>
        /// <value>A value indicating whether the TargetTask is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the name on the TargetTask.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets the outputs on the TargetTask.
        /// </summary>
        /// <value>The outputs.</value>
        public ImmutableArray<Output> Outputs { get; internal set; } = ImmutableArray<Output>.Empty;

        /// <summary>
        /// Gets the parameters on the TargetTask.
        /// </summary>
        /// <value>The parameters.</value>
        public ImmutableArray<Parameter> Parameters { get; internal set; } = ImmutableArray<Parameter>.Empty;

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

            XAttribute[] attributes = Parameters
                .Where(parameter => !parameter.IsUndefined)
                .Select(parameter => new XAttribute(parameter.Name.ToXmlElementName(), parameter.Value.ToString()))
                .ToArray();

            ImmutableArray<XElement> outputs = Outputs.Get(output => !output.IsUndefined);

            return ImmutableArray.Create(new XElement(
                Name.ToXmlElementName(),
                Condition.ToXmlAttribute(nameof(Condition))
                .And(ContinueOnError.ToXmlAttribute())
                .And(attributes)
                .And(outputs)));
        }

        /// <summary>
        /// Returns the string representation of the TargetTask.
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
        /// Validates the TargetTask.
        /// </summary>
        /// <remarks>Required members include: Condition, Name, Outputs, Parameters.</remarks>
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
                .AndIf(!Outputs.IsDefaultOrEmpty, nameof(Outputs), output => !output.IsUndefined, Outputs)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .Results;
        }
    }
}