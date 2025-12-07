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

        public Methods Behaviours { get; set; } = Methods.Default;

        public Snippet Default { get; set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public Scope Scope { get; set; } = Scope.Public;

        public Symbol Type { get; set; } = Symbol.Unspecified;

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
            var methods = Snippet.From(Behaviours.ToString(options, Scope));

            if (Default.IsEmpty)
            {
                methods = methods.Append(options, $" = {Default}");
            }

            return methods
                .Block(options, signature)
                .ToString();
        }

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
            string name = Name.ToString(Identifier.Options.Pascal);
            string scope = Scope;
            string type = Type;
            string signature = Separator.Combine(scope, type, name);

            return Snippet.From(signature);
        }
    }
}