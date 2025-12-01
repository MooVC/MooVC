namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Definition<T>
        : IValidatableObject
        where T : Construct, new()
    {
        public static readonly Definition<T> Empty = new Definition<T>();

        public T Construct { get; set; } = new T();

        public bool IsEmpty => this == Empty;

        public Qualifier Namespace { get; set; } = Qualifier.Unqualified;

        public ImmutableArray<Directive> Usings { get; set; } = ImmutableArray<Directive>.Empty;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEmpty)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Construct), _ => !Construct.IsUndefined, Construct)
                .And(nameof(Namespace), _ => !Namespace.IsUnqualified, Namespace)
                .AndIf(!Usings.IsDefaultOrEmpty, nameof(Usings), @using => !@using.IsUndefined, Usings)
                .Results;
        }
    }
}