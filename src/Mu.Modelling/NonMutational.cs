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
public sealed partial class NonMutational
    : IValidatableObject
{
    public static readonly NonMutational Undefined = new();

    [Descriptor("From")]
    [Hide]
    public Kind Source { get; internal init; } = Kind.ReadStore;

    [Descriptor("Using")]
    public Identifier View { get; internal init; } = Identifier.Unnamed;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .Include(nameof(View), _ => !View.IsUnnamed, View)
            .Results;
    }
}