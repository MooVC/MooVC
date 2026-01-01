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
    /// Represents a msbuild project attribute target.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Target
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Target.
        /// </summary>
        public static readonly Target Undefined = new Target();

        /// <summary>
        /// Initializes a new instance of the Target class.
        /// </summary>
        internal Target()
        {
        }

        /// <summary>
        /// Gets or sets the after targets on the Target.
        /// </summary>
        public Snippet AfterTargets { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the before targets on the Target.
        /// </summary>
        public Snippet BeforeTargets { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the condition on the Target.
        /// </summary>
        [Descriptor("OnCondition")]
        public Snippet Condition { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the depends on targets on the Target.
        /// </summary>
        public Snippet DependsOnTargets { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the inputs on the Target.
        /// </summary>
        public Snippet Inputs { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Target is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the keep duplicate outputs on the Target.
        /// </summary>
        public bool KeepDuplicateOutputs { get; internal set; }

        /// <summary>
        /// Gets or sets the label on the Target.
        /// </summary>
        [Descriptor("KnownAs")]
        public Snippet Label { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the name on the Target.
        /// </summary>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the outputs on the Target.
        /// </summary>
        public Snippet Outputs { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the returns on the Target.
        /// </summary>
        public Snippet Returns { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the tasks on the Target.
        /// </summary>
        public ImmutableArray<TargetTask> Tasks { get; internal set; } = ImmutableArray<TargetTask>.Empty;

        /// <summary>
        /// Performs the To Fragments operation for the msbuild project attribute.
        /// </summary>
        public ImmutableArray<XElement> ToFragments()
        {
            if (IsUndefined)
            {
                return ImmutableArray<XElement>.Empty;
            }

            XElement[] tasks = Tasks
                .Where(task => !task.IsUndefined)
                .SelectMany(task => task.ToFragments())
                .ToArray();

            ImmutableArray<XElement>.Builder builder = ImmutableArray.CreateBuilder<XElement>(1);

            builder.Add(new XElement(
                nameof(Target),
                AfterTargets.ToXmlAttribute(nameof(AfterTargets)),
                BeforeTargets.ToXmlAttribute(nameof(BeforeTargets)),
                Condition.ToXmlAttribute(nameof(Condition)),
                DependsOnTargets.ToXmlAttribute(nameof(DependsOnTargets)),
                Inputs.ToXmlAttribute(nameof(Inputs)),
                KeepDuplicateOutputs.ToXmlAttribute(nameof(KeepDuplicateOutputs)),
                Label.ToXmlAttribute(nameof(Label)),
                Name.ToXmlAttribute(nameof(Name)),
                Outputs.ToXmlAttribute(nameof(Outputs)),
                Returns.ToXmlAttribute(nameof(Returns)),
                tasks));

            return builder.ToImmutable();
        }

        /// <summary>
        /// Returns the string representation of the Target.
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
        /// Validates the Target and returns validation results.
        /// </summary>
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