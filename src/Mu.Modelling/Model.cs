namespace Mu.Modelling;

using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using Fluentify;
using Graphify;
using MooVC.Syntax.Elements;
using MooVC.Syntax.Validation;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;
using Options = MooVC.Syntax.CSharp.Concepts.Options;

[Fluentify]
[Graphify]
[Valuify]
public sealed partial class Model
    : IValidatableObject
{
    public static readonly Model Undefined = new();

    [Descriptor("WithArea")]
    public ImmutableArray<Area> Areas { get; internal init; } = [];

    [Descriptor("For")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Company { get; internal init; } = Name.Unnamed;

    [Ignore]
    [Traverse(Scope = TraverseScope.None)]
    public bool IsUndefined => this == Undefined;

    [Descriptor("Named")]
    [Traverse(Scope = TraverseScope.Property)]
    public Name Name { get; internal init; } = Name.Unnamed;

    [Traverse(Scope = TraverseScope.None)]
    public Options Options { get; internal init; } = Options.Default;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return [];
        }

        return validationContext
            .IncludeIf(!Areas.IsDefaultOrEmpty, nameof(Areas), area => !area.IsUndefined, Areas)
            .AndIf(!Company.IsUnnamed, nameof(Company), Company)
            .And(nameof(Name), name => !name.IsUnnamed, Name)
            .Results;
    }
}