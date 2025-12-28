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
public sealed partial class TaskParameter
    : IValidatableObject
{
    public static readonly TaskParameter Undefined = new TaskParameter();

    internal TaskParameter()
    {
    }

    [Ignore]
    public bool IsUndefined => this == Undefined;

    public Identifier Name { get; internal set; } = Identifier.Unnamed;

    public Snippet Value { get; internal set; } = Snippet.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (IsUndefined)
        {
            return Enumerable.Empty<ValidationResult>();
        }

        return validationContext
            .Include(nameof(Name), _ => !Name.IsUnnamed, Name)
            .Results;
    }
}