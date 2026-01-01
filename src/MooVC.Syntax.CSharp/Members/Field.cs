namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.CSharp.Syntax;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Field_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax field.
    /// </summary>
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
        /// Gets or sets the default on the Field.
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
        /// Gets or sets the name on the Field.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets or sets the scope on the Field.
        /// </summary>
        /// <value>The scope.</value>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Gets or sets the type on the Field.
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
        /// Returns the string representation of the Field.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Field)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            string signature = GetSignature();

            if (!Default.IsEmpty)
            {
                signature = $"{signature} = {Default}";
            }

            signature = string.Concat(signature, ';');

            return Snippet.From(options, signature);
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

        private string GetSignature()
        {
            var name = Name.ToSnippet(Variable.Options.Pascal);
            string scope = Scope;
            string type = Type;
            string @static = IsStatic.Static();
            string @readonly = IsReadOnly.ReadOnly();

            return Separator.Combine(scope, @static, @readonly, type, name);
        }
    }
}