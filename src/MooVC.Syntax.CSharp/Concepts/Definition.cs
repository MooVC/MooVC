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
    /// Represents a C# type syntax definition.
    /// </summary>
    [AutoInitiateWith(nameof(Empty))]
    [Fluentify]
    [Valuify]
    public sealed partial class Definition<T>
        : IValidatableObject
        where T : Type, new()
    {
        /// <summary>
        /// Gets the empty instance.
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
        /// <value>A value indicating whether the Definition is empty.</value>
        [Ignore]
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets or sets the namespace on the Definition.
        /// </summary>
        /// <value>The namespace.</value>
        [Descriptor("From")]
        public Qualifier Namespace { get; internal set; } = Qualifier.Unqualified;

        /// <summary>
        /// Gets or sets the type on the Definition.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public T Type { get; internal set; } = new T();

        /// <summary>
        /// Gets or sets the usings on the Definition.
        /// </summary>
        /// <value>The usings.</value>
        public ImmutableArray<Directive> Usings { get; internal set; } = ImmutableArray<Directive>.Empty;

        /// <summary>
        /// Returns the string representation of the Definition.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# type syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
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
        /// Validates the Definition.
        /// </summary>
        /// <remarks>Required members include: Type, Namespace, Usings.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
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