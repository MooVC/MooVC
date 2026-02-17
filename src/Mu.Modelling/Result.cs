namespace Mu.Modelling;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using Graphify;
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
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Name { get; internal init; } = Name.Unnamed;

    [Descriptor("OfType")]
    [Traverse(Scope = TraverseScope.Property)]
    public Symbol Type { get; internal init; } = Symbol.Undefined;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
            .And(nameof(Type), _ => !Type.IsUndefined, Type)
            .Results;
    }
}