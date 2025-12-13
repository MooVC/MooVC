namespace MooVC.Syntax.CSharp.Members
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.CSharp.Syntax;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Field_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Field
        : IValidatableObject
    {
        public static readonly Field Undefined = new Field();

        private const string Separator = " ";

        internal Field()
        {
        }

        public Snippet Default { get; internal set; } = Snippet.Empty;

        public bool IsReadOnly { get; internal set; } = true;

        public bool IsStatic { get; internal set; }

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Scope Scope { get; internal set; } = Scope.Public;

        public Symbol Type { get; internal set; } = Symbol.Unspecified;

        public static implicit operator string(Field field)
        {
            Guard.Against.Conversion<Field, string>(field);

            return field.ToString();
        }

        public static implicit operator Snippet(Field field)
        {
            Guard.Against.Conversion<Field, Snippet>(field);

            return Snippet.From(field);
        }

        public override string ToString()
        {
            return ToString(Snippet.Options.Default);
        }

        public string ToString(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Snippet.Options), nameof(Snippet), nameof(Field)));

            if (IsUndefined)
            {
                return string.Empty;
            }

            Snippet signature = GetSignature();

            if (!Default.IsEmpty)
            {
                signature = signature.Append(options, $" = {Default}");
            }

            return signature
                .Append(';')
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
                    ValidateDefaultRequired.Format(nameof(Default), nameof(Field)),
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
            string @static = IsStatic.Static();
            string @readonly = IsReadOnly.ReadOnly();
            string signature = Separator.Combine(scope, @static, @readonly, type, name);

            return Snippet.From(signature);
        }
    }
}