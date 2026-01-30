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
public sealed partial class Attribute
    : IValidatableObject
{
    public static readonly Attribute Undefined = new();

    [Descriptor("DefaultedTo")]
    public Snippet Default { get; internal init; } = Snippet.Empty;

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
            .IncludeIf(!Default.IsEmpty, nameof(Default), _ => Default.IsSingleLine, Default)
            .And(nameof(Name), _ => !Name.IsUnnamed, Name)
            .And(nameof(Type), _ => !Type.IsUndefined, Type)
            .Results;
    }
}