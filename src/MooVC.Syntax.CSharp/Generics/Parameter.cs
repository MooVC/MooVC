namespace MooVC.Syntax.CSharp.Generics
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Valuify;
    using static MooVC.Syntax.CSharp.Generics.Parameter_Resources;

    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        public Identifier Name { get; set; } = Identifier.Unnamed;

        public ImmutableArray<Constraint> Constraints { get; set; } = ImmutableArray<Constraint>.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Parameter)), new[] { nameof(Name) }));
            }

            return validationContext
                .IncludeIf(!Constraints.IsDefaultOrEmpty, results, Constraints)
                .And(Name)
                .Results;
        }
    }
}