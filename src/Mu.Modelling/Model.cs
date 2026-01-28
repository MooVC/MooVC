namespace Mu.Modelling;

using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using Graphify;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Graphify]
[Valuify]
public sealed partial class Model
    : IValidatableObject
{
    public static readonly Model Undefined = new();

    [Descriptor("WithArea")]
    public ImmutableArray<Area> Areas { get; init; } = ImmutableArray<Area>.Empty;

    [Descriptor("For")]
    public Identifier Company { get; init; } = Identifier.Unnamed;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    public Identifier Name { get; init; } = Identifier.Unnamed;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!Areas.IsDefaultOrEmpty, nameof(Areas), Areas)
            .AndIf(!Company.IsUnnamed, nameof(Company), Company)
            .And(nameof(Name), Name)
            .Results;
    }
}