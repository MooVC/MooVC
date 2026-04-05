namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Field_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax field.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Field
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Field Undefined = new Field();

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Field class.
        /// </summary>
        internal Field()
        {
        }

        /// <summary>
        /// Gets the attributes associated with the Property.
        /// </summary>
        /// <value>The attributes.</value>
        [Descriptor("AttributedWith")]
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets the default on the Field.
        /// </summary>
        /// <value>The default.</value>
        public Snippet Default { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Field is read only.
        /// </summary>
        /// <value>A value indicating whether the Field is read only.</value>
        public bool IsReadOnly { get; internal set; } = true;

        /// <summary>
        /// Gets a value indicating whether the Field is static.
        /// </summary>
        /// <value>A value indicating whether the Field is static.</value>
        public bool IsStatic { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Field is undefined.
        /// </summary>
        /// <value>A value indicating whether the Field is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the name on the Field.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets the scope on the Field.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Private;

        /// <summary>
        /// Gets the type on the Field.
        /// </summary>
        /// <value>The type.</value>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Defines the string operator for the Field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Field field)
        {
            Guard.Against.Conversion<Field, string>(field);

            return field.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Field.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Field field)
        {
            Guard.Against.Conversion<Field, Snippet>(field);

            return Snippet.From(field);
        }

        /// <summary>
        /// Implicitly converts a tuple containing a name and type to an Field instance.
        /// </summary>
        /// <param name="field">The tuple containing the name and type to be converted into an Field.</param>
        /// <returns>The Field.</returns>
        public static implicit operator Field((Name Name, Symbol Type) field)
        {
            Guard.Against.Conversion<(Name Name, Symbol Type), Field>(field);

            return new Field()
                .Named(field.Name)
                .OfType(field.Type);
        }

        /// <summary>
        /// Returns the string representation of the Field.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Type.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Options), nameof(Snippet), nameof(Field)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            var attributes = Attributes.ToSnippet(options);
            string signature = GetSignature(options);

            if (!Default.IsEmpty)
            {
                signature = $"{signature} = {Default}";
            }

            signature = string.Concat(signature, ';');

            return Snippet
                .From(options, signature)
                .Prepend(options, attributes);
        }

        /// <summary>
        /// Validates the Field.
        /// </summary>
        /// <remarks>Required members include: Default, Name, Type.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Default.IsMultiLine)
            {
                results = results.Append(new ValidationResult(
                    ValidateDefaultRequired.Format(nameof(Default), nameof(Field)),
                    new[] { nameof(Default) }));
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, results, Name)
                .And(nameof(Type), _ => !Type.IsUndefined, Type)
                .Results;
        }

        private string GetSignature(Type.Options options)
        {
            var name = Name.ToSnippet(Variable.Options.Pascal);
            string scope = Scope;
            string type = Type.ToSnippet(options);
            string @static = IsStatic.Static();
            string @readonly = IsReadOnly.ReadOnly();

            return Separator.Combine(scope, @static, @readonly, type, name);
        }
    }
}