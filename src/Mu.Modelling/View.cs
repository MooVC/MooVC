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
public sealed partial class View
    : IValidatableObject
{
    public static readonly View Undefined = new();

    [Descriptor("AttributedWith")]
    [Traverse(Scope = TraverseScope.Property)]
    public ImmutableArray<Attribute> Attributes { get; internal init; } = [];

    [Descriptor("RenderedOn")]
    [Traverse(Scope = TraverseScope.Property)]
    public ImmutableArray<Qualifier> Facts { get; internal init; } = [];

    [Ignore]
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Name { get; internal init; } = Name.Unnamed;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUndefined, Attributes)
            .AndIf(!Facts.IsDefaultOrEmpty, nameof(Facts), fact => !fact.IsUnqualified, Facts)
            .And(nameof(Name), name => !name.IsUnnamed, Name)
            .Results;
    }
}