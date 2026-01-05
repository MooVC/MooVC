namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Ardalis.GuardClauses;
    using MooVC.Syntax.Concepts;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.CSharp.Operators;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Concepts.Type_Resources;
    using Attribute = MooVC.Syntax.CSharp.Members.Attribute;
    using Descriptor = Fluentify.DescriptorAttribute;

    /// <summary>
    /// Represents a C# type syntax type.
    /// </summary>
    public abstract class Type
        : Construct
    {
        private protected Type()
        {
        }

        /// <summary>
        /// Gets or sets the attributes on the Type.
        /// </summary>
        /// <value>The attributes.</value>
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets or sets the events on the Type.
        /// </summary>
        /// <value>The events.</value>
        public ImmutableArray<Event> Events { get; internal set; } = ImmutableArray<Event>.Empty;

        /// <summary>
        /// Gets or sets the indexers on the Type.
        /// </summary>
        /// <value>The indexers.</value>
        public ImmutableArray<Indexer> Indexers { get; internal set; } = ImmutableArray<Indexer>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Type is partial.
        /// </summary>
        /// <value>A value indicating whether the Type is partial.</value>
        public bool IsPartial { get; internal set; }

        /// <summary>
        /// Gets or sets the methods on the Type.
        /// </summary>
        /// <value>The methods.</value>
        public ImmutableArray<Method> Methods { get; internal set; } = ImmutableArray<Method>.Empty;

        /// <summary>
        /// Gets or sets the name on the will.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        [SuppressMessage("Usage", "FLTFY03:Type does not utilize Fluentify", Justification = "The base class will be annotated with it.")]
        public Declaration Name { get; internal set; } = Declaration.Unspecified;

        /// <summary>
        /// Gets or sets the operators on the will.
        /// </summary>
        /// <value>The operators.</value>
        public Operators Operators { get; internal set; } = new Operators();

        /// <summary>
        /// Gets or sets the properties on the will.
        /// </summary>
        /// <value>The properties.</value>
        public ImmutableArray<Property> Properties { get; internal set; } = ImmutableArray<Property>.Empty;

        /// <summary>
        /// Gets or sets the scope on the will.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Returns the string representation of the will.
        /// </summary>
        /// <returns>The string representation.</returns>
        public sealed override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), GetType().Name));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            return PerformToSnippet(options);
        }

        /// <summary>
        /// Validates the will.
        /// </summary>
        /// <remarks>Required members include: Name, Properties.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
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
                .And(nameof(Name), _ => !Name.IsUnspecified, Name)
                .AndIf(!Properties.IsDefaultOrEmpty, nameof(Properties), property => property.IsUndefined, Properties)
                .Results;
        }

        /// <summary>
        /// Performs the perform to snippet operation for the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The snippet.</returns>
        protected abstract Snippet PerformToSnippet(Snippet.Options options);
    }
}