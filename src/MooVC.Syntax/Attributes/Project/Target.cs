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
    /// Represents a MSBuild project attribute target.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Target
        : IProduceXml,
          IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Target Undefined = new Target();

        /// <summary>
        /// Initializes a new instance of the Target class.
        /// </summary>
        internal Target()
        {
        }

        /// <summary>
        /// Gets the after targets on the Target.
        /// </summary>
        /// <value>The after targets.</value>
        public Snippet AfterTargets { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the before targets on the Target.
        /// </summary>
        /// <value>The before targets.</value>
        public Snippet BeforeTargets { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the condition on the Target.
        /// </summary>
        /// <value>The condition.</value>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the depends on targets on the Target.
        /// </summary>
        /// <value>The depends on targets.</value>
        public Snippet DependsOnTargets { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the inputs on the Target.
        /// </summary>
        /// <value>The inputs.</value>
        public Snippet Inputs { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Target is undefined.
        /// </summary>
        /// <value>A value indicating whether the Target is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the keep duplicate outputs on the Target.
        /// </summary>
        /// <value>The keep duplicate outputs.</value>
        public bool KeepDuplicateOutputs { get; internal set; }

        /// <summary>
        /// Gets the label on the Target.
        /// </summary>
        /// <value>The label.</value>
        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the name on the Target.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Name Name { get; internal set; } = Name.Unnamed;

        /// <summary>
        /// Gets the outputs on the Target.
        /// </summary>
        /// <value>The outputs.</value>
        public Snippet Outputs { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the returns on the Target.
        /// </summary>
        /// <value>The returns.</value>
        public Snippet Returns { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets the tasks on the Target.
        /// </summary>
        /// <value>The tasks.</value>
        public ImmutableArray<TargetTask> Tasks { get; internal set; } = ImmutableArray<TargetTask>.Empty;

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

            ImmutableArray<XElement> tasks = Tasks.Get(task => !task.IsUndefined);

            return ImmutableArray.Create(new XElement(
                nameof(Target),
                AfterTargets.ToXmlAttribute(nameof(AfterTargets))
                .And(BeforeTargets.ToXmlAttribute(nameof(BeforeTargets)))
                .And(Condition.ToXmlAttribute(nameof(Condition)))
                .And(DependsOnTargets.ToXmlAttribute(nameof(DependsOnTargets)))
                .And(Inputs.ToXmlAttribute(nameof(Inputs)))
                .And(KeepDuplicateOutputs.ToXmlAttribute(nameof(KeepDuplicateOutputs)))
                .And(Label.ToXmlAttribute(nameof(Label)))
                .And(Name.ToXmlAttribute(nameof(Name)))
                .And(Outputs.ToXmlAttribute(nameof(Outputs)))
                .And(Returns.ToXmlAttribute(nameof(Returns)))
                .And(tasks)));
        }

        /// <summary>
        /// Returns the string representation of the Target.
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
        /// Validates the Target.
        /// </summary>
        /// <remarks>Required members include: AfterTargets, BeforeTargets, Condition, DependsOnTargets, Inputs, Label, Name, Outputs, Returns, Tasks.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(AfterTargets), _ => !AfterTargets.IsMultiLine, AfterTargets)
                .And(nameof(BeforeTargets), _ => !BeforeTargets.IsMultiLine, BeforeTargets)
                .And(nameof(Condition), _ => !Condition.IsMultiLine, Condition)
                .And(nameof(DependsOnTargets), _ => !DependsOnTargets.IsMultiLine, DependsOnTargets)
                .And(nameof(Inputs), _ => !Inputs.IsMultiLine, Inputs)
                .And(nameof(Label), _ => !Label.IsMultiLine, Label)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .And(nameof(Outputs), _ => !Outputs.IsMultiLine, Outputs)
                .And(nameof(Returns), _ => !Returns.IsMultiLine, Returns)
                .AndIf(!Tasks.IsDefaultOrEmpty, nameof(Tasks), task => !task.IsUndefined, Tasks)
                .Results;
        }
    }
}