namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Generics.Constraints;
    using Valuify;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        public static readonly Parameter Undefined = new Parameter();
        public static readonly Func<Parameter, string> Names = parameter => parameter.Name;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public ImmutableArray<Constraint> Constraints { get; set; } = ImmutableArray<Constraint>.Empty;

        [Ignore]
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
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Constraints.IsDefaultOrEmpty, nameof(Constraints), constraint => !constraint.IsUnspecified, Constraints)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .Results;
        }
    }
}