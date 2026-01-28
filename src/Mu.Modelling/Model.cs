namespace Mu.Modelling;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using Graphify;
using MooVC.Syntax.CSharp.Generics;
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

    public ImmutableArray<Context> Contexts { get; init; } = ImmutableArray<Context>.Empty;

    public Identifier Company { get; init; } = Identifier.Unnamed;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public Identifier Name { get; init; } = Identifier.Unnamed;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!Contexts.IsDefaultOrEmpty, nameof(Contexts), Contexts)
            .AndIf(!Company.IsUnnamed, nameof(Company), Company)
            .And(nameof(Name), Name)
            .Results;
    }
}