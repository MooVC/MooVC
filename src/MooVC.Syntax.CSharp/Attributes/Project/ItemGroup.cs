namespace MooVC.Syntax.CSharp.Attributes.Project;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Fluentify;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class ItemGroup
    : IValidatableObject
{
    public static readonly ItemGroup Undefined = new ItemGroup();

    internal ItemGroup()
    {
    }

    public Snippet Condition { get; internal set; } = Snippet.Empty;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public ImmutableArray<Item> Items { get; internal set; } = ImmutableArray<Item>.Empty;

    public Snippet Label { get; internal set; } = Snippet.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!Items.IsDefaultOrEmpty, nameof(Items), item => !item.IsUndefined, Items)
            .Results;
    }
}