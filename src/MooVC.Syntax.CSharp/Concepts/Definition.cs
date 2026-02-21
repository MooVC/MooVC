namespace MooVC.Syntax.CSharp.Concepts
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Concepts;
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
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Definition
        : Construct
    {
        /// <summary>
        /// Gets the empty instance.
        /// </summary>
        public static readonly Definition Undefined = new Definition();

        /// <summary>
        /// Gets a value indicating whether the Definition is empty.
        /// </summary>
        /// <value>A value indicating whether the Definition is empty.</value>
        [Ignore]
        public override bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the namespace on the Definition.
        /// </summary>
        /// <value>The namespace.</value>
        [Descriptor("From")]
        public Qualifier Namespace { get; internal set; } = Qualifier.Unqualified;

        /// <summary>
        /// Gets the type on the Definition.
        /// </summary>
        /// <value>The type.</value>
        [Hide]
        public Type Type { get; internal set; }

        /// <summary>
        /// Gets the usings on the Definition.
        /// </summary>
        /// <value>The usings.</value>
        [Descriptor("Referencing")]
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
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Definition)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            var type = Type.ToSnippet(options.Snippets);

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
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
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