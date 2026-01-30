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
public sealed partial class Feature
    : IValidatableObject
{
    public static readonly Feature Undefined = new();

    [Ignore]
    public bool IsUndefined => this == Undefined;

    [Hide]
    public Mutational Mutational { get; internal init; } = Mutational.Undefined;

    [Descriptor("Named")]
    public Identifier Name { get; internal init; } = Identifier.Unnamed;

    [Hide]
    public NonMutational NonMutational { get; internal init; } = NonMutational.Undefined;

    [Descriptor("Using")]
    public ImmutableArray<Parameter> Parameters { get; internal init; } = ImmutableArray<Parameter>.Empty;

    [Descriptor("Returning")]
    public ImmutableArray<Result> Results { get; internal init; } = ImmutableArray<Result>.Empty;

    [Descriptor("OfType")]
    public Kind Type { get; internal init; } = Kind.Mutational;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(Type.IsMutational, nameof(Mutational), mutational => !mutational.IsUndefined, Mutational)
            .And(nameof(Name), _ => !Name.IsUnnamed, Name)
            .AndIf(Type.IsNonMutational, nameof(NonMutational), nonmutational => !nonmutational.IsUndefined, NonMutational)
            .AndIf(!Parameters.IsDefaultOrEmpty, nameof(Parameters), parameter => !parameter.IsUndefined, Parameters)
            .Results;
    }
}