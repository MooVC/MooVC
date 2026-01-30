namespace Mu.Modelling;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fluentify;
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
    public Identifier Fact { get; internal init; } = Identifier.Unnamed;

    [Descriptor("OfType")]
    [Hide]
    public Kind Type { get; internal init; } = Kind.Transitional;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .Include(nameof(Fact), _ => !Fact.IsUnnamed, Fact)
            .Results;
    }
}