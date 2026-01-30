namespace Mu.Modelling;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class Result
    : IValidatableObject
{
    public static readonly Result Undefined = new();

    [Ignore]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    public Identifier Name { get; internal init; } = Identifier.Unnamed;

    [Descriptor("OfType")]
    public Symbol Type { get; internal init; } = Symbol.Undefined;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
            .And(nameof(Type), _ => !Type.IsUndefined, Type)
            .Results;
    }
}