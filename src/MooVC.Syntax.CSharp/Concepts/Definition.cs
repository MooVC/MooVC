namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using Valuify;
    using static MooVC.Syntax.CSharp.Concepts.Definition_Resources;

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

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Namespace.IsUnqualified)
            {
                results = results.Append(new ValidationResult(ValidateNamespaceRequired.Format(nameof(Namespace), nameof(Construct)), new[] { nameof(Namespace) }));
            }

            if (!Construct.IsUndefined)
            {
                results = results.Append(new ValidationResult(ValidateConstructInvalid.Format(Namespace, nameof(Construct)), new[] { nameof(Construct) }));
            }

            return validationContext
                .Include(nameof(Construct), results, Construct)
                .And(nameof(Namespace), Namespace)
                .AndIf(!Usings.IsDefaultOrEmpty, nameof(Usings), Usings)
                .Results;
        }
    }
}