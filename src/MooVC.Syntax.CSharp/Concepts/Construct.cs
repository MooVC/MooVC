namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.CSharp.Operators;
    using static MooVC.Syntax.CSharp.Concepts.Construct_Resources;
    using Attribute = MooVC.Syntax.CSharp.Members.Attribute;
    using Descriptor = Fluentify.DescriptorAttribute;
    using Ignore = Valuify.IgnoreAttribute;

    public abstract class Construct
        : IValidatableObject
    {
        private protected Construct()
        {
        }

        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        public ImmutableArray<Event> Events { get; internal set; } = ImmutableArray<Event>.Empty;

        public ImmutableArray<Indexer> Indexers { get; internal set; } = ImmutableArray<Indexer>.Empty;

        public bool IsPartial { get; internal set; }

        [Ignore]
        public abstract bool IsUndefined { get; }

        public ImmutableArray<Method> Methods { get; internal set; } = ImmutableArray<Method>.Empty;

        [Descriptor("Named")]
        [SuppressMessage("Usage", "FLTFY03:Type does not utilize Fluentify", Justification = "The base class will be annotated with it.")]
        public Declaration Name { get; internal set; } = Declaration.Unspecified;

        public Operators Operators { get; internal set; } = new Operators();

        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        public Scope Scope { get; internal set; } = Scope.Public;

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(GetType().Name));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            return ToSnippet(options);
        }

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

        protected abstract Snippet ToSnippet(Snippet.Options options);
    }
}