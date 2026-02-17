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
public sealed partial class Feature
    : IValidatableObject
{
    public static readonly Feature Undefined = new();

    [Ignore]
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    [Hide]
    [Traverse(Scope = TraverseScope.Property)]
    public Mutational Mutational { get; internal init; } = Mutational.Undefined;

    [Descriptor("Named")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Name { get; internal init; } = Name.Unnamed;

    [Hide]
    [Traverse(Scope = TraverseScope.Property)]
    public NonMutational NonMutational { get; internal init; } = NonMutational.Undefined;

    [Descriptor("Using")]
    [Traverse(Scope = TraverseScope.Property)]
    public ImmutableArray<Parameter> Parameters { get; internal init; } = [];

    [Descriptor("Returning")]
    [Traverse(Scope = TraverseScope.Property)]
    public ImmutableArray<Result> Results { get; internal init; } = [];

    [Descriptor("OfType")]
    [Traverse(Scope = TraverseScope.Property)]
    public Kind Type { get; internal init; } = Kind.Mutational;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .IncludeIf(Type.IsMutational, nameof(Mutational), mutational => !mutational.IsUndefined, Mutational)
            .And(nameof(Name), _ => !Name.IsUnnamed, Name)
            .AndIf(Type.IsNonMutational, nameof(NonMutational), nonmutational => !nonmutational.IsUndefined, NonMutational)
            .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
            .Results;
    }
}