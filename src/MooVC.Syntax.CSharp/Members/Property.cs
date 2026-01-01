namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Property_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a c# member syntax property.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Property
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Property.
        /// </summary>
        public static readonly Property Undefined = new Property();

        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        internal Property()
        {
        }

        /// <summary>
        /// Gets or sets the behaviours on the Property.
        /// </summary>
        public Methods Behaviours { get; internal set; } = Methods.Default;

        /// <summary>
        /// Gets or sets the default on the Property.
        /// </summary>
        public Snippet Default { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets or sets the extensibility on the Property.
        /// </summary>
        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        /// <summary>
        /// Gets a value indicating whether the Property is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the name on the Property.
        /// </summary>
        [Descriptor("Named")]
        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets or sets the scope on the Property.
        /// </summary>
        public Scope Scope { get; internal set; } = Scope.Public;

        /// <summary>
        /// Gets or sets the type on the Property.
        /// </summary>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Defines the string operator for the Property.
        /// </summary>
        public static implicit operator string(Property property)
        {
            Guard.Against.Conversion<Property, string>(property);

            return property.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Property.
        /// </summary>
        public static implicit operator Snippet(Property property)
        {
            Guard.Against.Conversion<Property, Snippet>(property);

            return Snippet.From(property);
        }

        /// <summary>
        /// Returns the string representation of the Property.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# member syntax.
        /// </summary>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Property)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            Snippet signature = GetSignature();
            var behaviours = Behaviours.ToSnippet(options, Scope);
            Snippet.Options body = options;

            if (behaviours.IsSingleLine && options.Block.Inline.IsLambda && (Behaviours.Get.IsEmpty || !Behaviours.Set.Mode.IsReadOnly))
            {
                body = options.WithBlock(block => block
                    .WithInline(inline => Snippet.BlockOptions.InlineStyle.SingleLineBraces));
            }

            signature = behaviours.Block(body, signature);

            if (!Default.IsEmpty)
            {
                signature = signature.Append(options, $" = {Default}");
            }

            return signature;
        }

        /// <summary>
        /// Validates the Property and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (!Extensibility.IsPermitted(
                Extensibility.Abstract,
                Extensibility.Implicit,
                Extensibility.Override,
                Extensibility.Sealed + Extensibility.Override,
                Extensibility.Virtual))
            {
                results = results.Append(new ValidationResult(
                    ValidateExtensibilityInvalid.Format(nameof(Extensibility), Extensibility, nameof(Event)),
                    new[] { nameof(Extensibility) }));
            }

            if (Default.IsMultiLine)
            {
                results = results.Append(new ValidationResult(
                    ValidateDefaultRequired.Format(nameof(Default), nameof(Property)),
                    new[] { nameof(Default) }));
            }

            return validationContext
                .Include(nameof(Name), _ => !Name.IsUnnamed, results, Name)
                .And(nameof(Type), _ => !Type.IsUndefined, Type)
                .Results;
        }

        private Snippet GetSignature()
        {
            string extensibility = Extensibility;
            var name = Name.ToSnippet(Identifier.Options.Pascal);
            string scope = Scope;
            string type = Type;
            string signature = Separator.Combine(scope, extensibility, type, name);

            return Snippet.From(signature);
        }
    }
}