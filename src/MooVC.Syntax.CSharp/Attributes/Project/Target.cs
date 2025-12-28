namespace MooVC.Syntax.CSharp.Attributes.Project
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
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

        public Snippet Label { get; internal set; } = Snippet.Empty;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Snippet Outputs { get; internal set; } = Snippet.Empty;

        public ImmutableArray<TargetTask> Tasks { get; internal set; } = ImmutableArray<TargetTask>.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
                .AndIf(!Tasks.IsDefaultOrEmpty, nameof(Tasks), task => !task.IsUndefined, Tasks)
                .Results;
        }
    }
}