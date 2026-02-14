namespace Mu.Modelling;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using Graphify;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class Mutational
    : IValidatableObject
{
    public static readonly Mutational Undefined = new();

    [Descriptor("Yields")]
    [Traverse(Scope = TraverseScope.Property)]
    public Identifier Fact { get; internal init; } = Identifier.Unnamed;

    [Descriptor("OfType")]
    [Hide]
    [Traverse(Scope = TraverseScope.Property)]
    public Kind Type { get; internal init; } = Kind.Transitional;

    [Ignore]
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .Include(nameof(Fact), _ => !Fact.IsUnnamed, Fact)
            .Results;
    }
}