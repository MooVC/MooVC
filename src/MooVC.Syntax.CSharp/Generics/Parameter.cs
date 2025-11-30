namespace MooVC.Syntax.CSharp.Generics
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Valuify;
    using static MooVC.Syntax.CSharp.Generics.Parameter_Resources;

    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        public static readonly Parameter Undefined = new Parameter();

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public ImmutableArray<Constraint> Constraints { get; set; } = ImmutableArray<Constraint>.Empty;

        public bool IsUndefined => this == Undefined;

        public static implicit operator string(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, string>(parameter);

            return parameter.ToString();
        }

        public static implicit operator Snippet(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, Snippet>(parameter);

            return Snippet.From(parameter);
        }

        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Parameter)), new[] { nameof(Name) }));
            }

            return validationContext
                .IncludeIf(!Constraints.IsDefaultOrEmpty, nameof(Constraints), constraint => !constraint.IsUnspecified, results, Constraints)
                .And(nameof(Name), Name)
                .Results;
        }
    }
}