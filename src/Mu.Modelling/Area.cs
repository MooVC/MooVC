namespace Mu.Modelling;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using Graphify;
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

    [Descriptor("DescribedAs")]
    [Traverse(Scope = TraverseScope.Property)]
    public Description Description { get; internal init; } = Description.Undescribed;

    [Ignore]
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Name { get; internal init; } = Name.Unnamed;

    [Descriptor("ResponsibleFor")]
    public ImmutableArray<Unit> Units { get; internal init; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .IncludeIf(!Units.IsDefaultOrEmpty, nameof(Units), unit => !unit.IsUndefined, Units)
            .And(nameof(Name), name => !name.IsUnnamed, Name)
            .Results;
    }
}