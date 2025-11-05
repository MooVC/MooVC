namespace MooVC.Syntax.CSharp.Containers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Containers.Directive_Resources;

    [Fluentify]
    [Valuify]
    public sealed partial class Directive
        : IValidatableObject
    {
        public static readonly Directive Undefined = new Directive();

        public Identifier Alias { get; set; } = Identifier.Unnamed;

        public bool IsUndefined => this == Undefined;

        public bool IsStatic { get; set; }

        public Qualifier Qualifier { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (IsStatic && !Alias.IsUnnamed)
            {
                results = results.Append(new ValidationResult(ValidateStaticAliasInvalid.Format(Alias, Qualifier), new[] { nameof(Alias) }));
            }

            return results
                .And(validationContext, Alias)
                .And(validationContext, Qualifier);
        }
    }
}