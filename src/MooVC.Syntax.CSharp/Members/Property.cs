namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Property_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Property
        : IValidatableObject
    {
        public static readonly Property Undefined = new Property();

        private const string Separator = " ";

        internal Property()
        {
        }

        public Methods Behaviours { get; internal set; } = Methods.Default;

        public Snippet Default { get; internal set; } = Snippet.Empty;

        public Extensibility Extensibility { get; internal set; } = Extensibility.Implicit;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Scope Scope { get; internal set; } = Scope.Public;

        public Symbol Type { get; internal set; } = Symbol.Unspecified;

        public static implicit operator string(Property property)
        {
            Guard.Against.Conversion<Property, string>(property);

            return property.ToString();
        }

        public static implicit operator Snippet(Property property)
        {
            Guard.Against.Conversion<Property, Snippet>(property);

            return Snippet.From(property);
        }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Property)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature();

            signature = Snippet
                .From(Behaviours.ToString(options, Scope))
                .Block(options, signature);

            if (!Default.IsEmpty)
            {
                signature = signature.Append(options, $" = {Default}");
            }

            return signature.ToString();
        }

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
                .And(nameof(Type), _ => !Type.IsUnspecified, Type)
                .Results;
        }

        private Snippet GetSignature()
        {
            string extensibility = Extensibility;
            string name = Name.ToString(Identifier.Options.Pascal);
            string scope = Scope;
            string type = Type;
            string signature = Separator.Combine(scope, extensibility, type, name);

            return Snippet.From(signature);
        }
    }
}