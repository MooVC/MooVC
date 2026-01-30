namespace Mu.Modelling;

using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class Unit
    : IValidatableObject
{
    public static readonly Unit Undefined = new();

    [Descriptor("AttributedWith")]
    public ImmutableArray<Attribute> Attributes { get; internal init; } = ImmutableArray<Attribute>.Empty;

    [Descriptor("Featuring")]
    public ImmutableArray<Feature> Features { get; internal init; } = ImmutableArray<Feature>.Empty;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    public Identifier Name { get; internal init; } = Identifier.Unnamed;

    [Descriptor("SeenAs")]
    public ImmutableArray<View> Views { get; internal init; } = ImmutableArray<View>.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUndefined, Attributes)
            .AndIf(!Features.IsDefaultOrEmpty, nameof(Features), feature => !feature.IsUndefined, Features)
            .And(nameof(Name), name => !name.IsUnnamed, Name)
            .AndIf(!Views.IsDefaultOrEmpty, nameof(Views), view => !view.IsUndefined, Views)
            .Results;
    }
}