namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Parameter_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        public static readonly Parameter Undefined = new Parameter();

        public ImmutableArray<Attribute> Attributes { get; set; } = ImmutableArray<Attribute>.Empty;

        public Snippet Default { get; set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Mode Modifier { get; set; } = Mode.None;

        public Identifier Name { get; set; } = Identifier.Unnamed;

        public Symbol Type { get; set; } = Symbol.Unspecified;

        public static implicit operator string(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, string>(parameter);

            return parameter.ToString();
        }

        public static implicit operator Snippet(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, Snippet>(parameter);

            return Snippet.From(parameter);
        }

        public override string ToString()
        {
            return ToString(Options.Camel);
        }

        public string ToString(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Options), nameof(Parameter), nameof(Name), Name));

            if (IsUndefined)
            {
                return string.Empty;
            }

            const string separator = " ";

            string attributes = GetAttributes();
            string @default = GetDefault();
            string modifier = Modifier;
            string name = Name.ToString(options.Naming);
            string type = Type.ToString(options.Types);

            return separator.Combine(attributes, modifier, type, name, @default);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (Name.IsUnnamed)
            {
                results = results.Append(new ValidationResult(
                    ValidateNameRequired.Format(nameof(Name), nameof(Parameter)),
                    new[] { nameof(Name) }));
            }

            if (Type.IsUnspecified)
            {
                results = results.Append(new ValidationResult(
                    ValidateTypeRequired.Format(nameof(Name), nameof(Parameter), nameof(Name), Name),
                    new[] { nameof(Name) }));
            }

            if (Default.IsMultiLine)
            {
                results = results.Append(new ValidationResult(
                    ValidateDefaultInvalid.Format(nameof(Default), nameof(Parameter), nameof(Type), Type, nameof(Name), Name),
                    new[] { nameof(Default) }));
            }

            return validationContext
                .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUnspecified, results, Attributes)
                .And(nameof(Name), Name)
                .And(nameof(Type), Type)
                .Results;
        }

        private string GetAttributes()
        {
            if (Attributes.IsDefaultOrEmpty)
            {
                return string.Empty;
            }

            const string separator = ", ";

            string attributes = separator.Combine(Attributes, attribute => attribute);

            return $"[{attributes}]";
        }

        private string GetDefault()
        {
            return Default.IsSingleLine
                ? $"= {Default}"
                : string.Empty;
        }
    }
}