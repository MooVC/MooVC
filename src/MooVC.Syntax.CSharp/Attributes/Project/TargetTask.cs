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
    public sealed partial class TargetTask
        : IValidatableObject
    {
        public static readonly TargetTask Undefined = new TargetTask();

        internal TargetTask()
        {
        }

        public Snippet Condition { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public ImmutableArray<TaskOutput> Outputs { get; internal set; } = ImmutableArray<TaskOutput>.Empty;

        public ImmutableArray<TaskParameter> Parameters { get; internal set; } = ImmutableArray<TaskParameter>.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
                .AndIf(!Outputs.IsDefaultOrEmpty, nameof(Outputs), output => !output.IsUndefined, Outputs)
                .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
                .Results;
        }
    }
}