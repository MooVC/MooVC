namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Xml.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Target
        : IValidatableObject
    {
        public static readonly Target Undefined = new Target();

        internal Target()
        {
        }

        public Snippet AfterTargets { get; internal set; } = Snippet.Empty;

        public Snippet BeforeTargets { get; internal set; } = Snippet.Empty;

        public Snippet Condition { get; internal set; } = Snippet.Empty;

        public Snippet DependsOnTargets { get; internal set; } = Snippet.Empty;

        public Snippet Inputs { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public bool KeepDuplicateOutputs { get; internal set; }

        public Snippet Label { get; internal set; } = Snippet.Empty;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Snippet Outputs { get; internal set; } = Snippet.Empty;

        public Snippet Returns { get; internal set; } = Snippet.Empty;

        public ImmutableArray<TargetTask> Tasks { get; internal set; } = ImmutableArray<TargetTask>.Empty;

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

        public XElement ToFragment()
        {
            var tasks = Tasks
                .Where(task => !task.IsUndefined)
                .Select(task => task.ToFragment());

            return new XElement(
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
                tasks);
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