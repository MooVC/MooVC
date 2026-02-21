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
[Valuify]
public sealed partial class Unit
    : IValidatableObject
{
    public static readonly Unit Undefined = new();

    [Descriptor("AttributedWith")]
    [Traverse(Scope = TraverseScope.Property)]
    public ImmutableArray<Attribute> Attributes { get; internal init; } = [];

    [Descriptor("Owns")]
    public ImmutableArray<Component> Components { get; internal init; } = [];

    [Descriptor("DescribedAs")]
    [Traverse(Scope = TraverseScope.Property)]
    public Description Description { get; internal init; } = Description.Undescribed;

    [Descriptor("Featuring")]
    public ImmutableArray<Feature> Features { get; internal init; } = [];

    [Ignore]
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Name { get; internal init; } = Name.Unnamed;

    [Descriptor("SeenAs")]
    public ImmutableArray<View> Views { get; internal init; } = [];

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUndefined, Attributes)
            .AndIf(!Components.IsDefaultOrEmpty, nameof(Components), component => !component.IsUndefined, Components)
            .AndIf(!Features.IsDefaultOrEmpty, nameof(Features), feature => !feature.IsUndefined, Features)
            .And(nameof(Name), name => !name.IsUnnamed, Name)
            .AndIf(!Views.IsDefaultOrEmpty, nameof(Views), view => !view.IsUndefined, Views)
            .Results;
    }
}