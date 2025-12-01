namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using Attribute = MooVC.Syntax.CSharp.Members.Attribute;

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

            return validationContext
                .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUnspecified, Attributes)
                .AndIf(!Events.IsDefaultOrEmpty, nameof(Events), @event => !@event.IsUndefind, Events)
                .AndIf(!Indexers.IsDefaultOrEmpty, nameof(Indexers), indexer => indexer.IsUndefined, Indexers)
                .AndIf(!Methods.IsDefaultOrEmpty, nameof(Methods), method => method.IsUndefined, Methods)
                .And(nameof(Name), _ => !Name.IsUnspecified,  Name)
                .AndIf(!Properties.IsDefaultOrEmpty, nameof(Properties), property => property.IsUndefined, Properties)
                .Results;
        }
    }
}