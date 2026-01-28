namespace Mu.Modelling;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class Area
    : IValidatableObject
{
    public static readonly Area Undefined = new();

    [Ignore]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    public Identifier Name { get; init; } = Identifier.Unnamed;

    [Descriptor("ResponsibleFor")]
    public ImmutableArray<Unit> Units { get; init; } = ImmutableArray<Unit>.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!Units.IsDefaultOrEmpty, nameof(Units), Units)
            .And(nameof(Name), Name)
            .Results;
    }
}