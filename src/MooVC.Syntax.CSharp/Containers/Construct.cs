namespace MooVC.Syntax.CSharp.Containers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using static MooVC.Syntax.CSharp.Containers.Construct_Resources;

    public abstract class Construct
        : IValidatableObject
    {
        private protected Construct()
        {
        }

        public ImmutableArray<Attribute> Attributes { get; set; } = ImmutableArray<Attribute>.Empty;

        public ImmutableArray<Event> Events { get; set; } = ImmutableArray<Event>.Empty;

        public ImmutableArray<Indexer> Indexers { get; set; } = ImmutableArray<Indexer>.Empty;

        public abstract bool IsUndefined { get; }

        public ImmutableArray<Method> Methods { get; set; } = ImmutableArray<Method>.Empty;

        [Descriptor("Named")]
        [SuppressMessage("Usage", "FLTFY03:Type does not utilize Fluentify", Justification = "The base class will be annotated with it.")]
        public Declaration Name { get; set; } = Declaration.Unspecified;

        public ImmutableArray<Property> Properties { get; set; } = ImmutableArray<Property>.Empty;

        public Scope Scope { get; set; } = Scope.Public;

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Array.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnspecified)
            {
                results = results.Append(new ValidationResult(ValidateNameRequired.Format(nameof(Name), nameof(Construct)), new[] { nameof(Name) }));
            }

            return validationContext
                .Include(results, Attributes)
                .And(Events)
                .And(Indexers)
                .And(Methods)
                .And(Name)
                .And(Properties)
                .Results;
        }
    }
}