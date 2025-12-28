namespace MooVC.Syntax.CSharp.Attributes.Project;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Fluentify;
using MooVC.Syntax.CSharp.Elements;
using Valuify;
using Ignore = Valuify.IgnoreAttribute;

[Fluentify]
[Valuify]
public sealed partial class TaskOutput
    : IValidatableObject
{
    public static readonly TaskOutput Undefined = new TaskOutput();

    internal TaskOutput()
    {
    }

    public Snippet Condition { get; internal set; } = Snippet.Empty;

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public Identifier ItemName { get; internal set; } = Identifier.Unnamed;

    public Identifier PropertyName { get; internal set; } = Identifier.Unnamed;

    public Identifier TaskParameter { get; internal set; } = Identifier.Unnamed;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .IncludeIf(!ItemName.IsUnnamed, nameof(ItemName), ItemName)
            .AndIf(!PropertyName.IsUnnamed, nameof(PropertyName), PropertyName)
            .AndIf(!TaskParameter.IsUnnamed, nameof(TaskParameter), TaskParameter)
            .Results;
    }
}