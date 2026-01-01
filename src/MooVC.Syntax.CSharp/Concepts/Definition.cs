namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Concepts.Definition_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# type syntax definition.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Definition<T>
        : IValidatableObject
        where T : Type, new()
    {
        /// <summary>
        /// Gets the empty on the Definition.
        /// </summary>
        public static readonly Definition<T> Empty = new Definition<T>();

        /// <summary>
        /// Initializes a new instance of the Definition class.
        /// </summary>
        internal Definition()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the Definition is empty.
        /// </summary>
        [Ignore]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets or sets the namespace on the Definition.
        /// </summary>
        [Descriptor("From")]
        public Qualifier Namespace { get; internal set; } = Qualifier.Unqualified;

        /// <summary>
        /// Gets or sets the type on the Definition.
        /// </summary>
        [Descriptor("OfType")]
        public T Type { get; internal set; } = new T();

        /// <summary>
        /// Gets or sets the usings on the Definition.
        /// </summary>
        public ImmutableArray<Directive> Usings { get; internal set; } = ImmutableArray<Directive>.Empty;

        /// <summary>
        /// Returns the string representation of the Definition.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# type syntax.
        /// </summary>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Definition<T>)));

            if (IsEmpty)
            {
                return string.Empty;
            }

            Snippet type = Type.ToSnippet(options.Snippets);

            if (type.IsEmpty)
            {
                return type;
            }

            Snippet @namespace = $"namespace {Namespace}";
            var usings = Usings.ToSnippet(options.Snippets);

            if (!usings.IsEmpty)
            {
                type = type
                    .Prepend(options.Snippets, Environment.NewLine)
                    .Prepend(options.Snippets, usings);
            }

            if (options.Namespace.IsBlock)
            {
                return type.Block(options.Snippets, @namespace);
            }

            @namespace = @namespace
                .Append(';')
                .Append(Environment.NewLine);

            return type.Stack(options.Snippets, @namespace);
        }

        /// <summary>
        /// Validates the Definition and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEmpty)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .Include(nameof(Type), _ => !Type.IsUndefined, Type)
                .And(nameof(Namespace), _ => !Namespace.IsUnqualified, Namespace)
                .AndIf(!Usings.IsDefaultOrEmpty, nameof(Usings), @using => !@using.IsUndefined, Usings)
                .Results;
        }
    }
}