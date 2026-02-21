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
public sealed partial class NonMutational
    : IValidatableObject
{
    public static readonly NonMutational Undefined = new();

    [Descriptor("DescribedAs")]
    [Traverse(Scope = TraverseScope.Property)]
    public Description Description { get; internal init; } = Description.Undescribed;

    [Descriptor("From")]
    [Hide]
    [Traverse(Scope = TraverseScope.Property)]
    public Kind Source { get; internal init; } = Kind.ReadStore;

    [Descriptor("Using")]
    [Traverse(Scope = TraverseScope.Property)]
    public View View { get; internal init; } = View.Undefined;

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
            .Include(nameof(View), _ => !View.IsUndefined, View)
            .Results;
    }
}