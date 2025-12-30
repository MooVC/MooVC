namespace MooVC.Syntax.CSharp.Elements
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Elements.Parameter_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        public static readonly Parameter Undefined = new Parameter();

        internal Parameter()
        {
        }

        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        public Snippet Default { get; internal set; } = Snippet.Empty;

        [Ignore]
        public bool IsUndefined => this == Undefined;

        public Mode Modifier { get; internal set; } = Mode.None;

        public Identifier Name { get; internal set; } = Identifier.Unnamed;

        public Symbol Type { get; internal set; } = Symbol.Undefined;

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
            return ToSnippet(Options.Camel);
        }

        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToStringOptionsRequired.Format(nameof(Options), nameof(Parameter), nameof(Name), Name));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            const string separator = " ";

            string attributes = GetAttributes();
            string @default = GetDefault();
            string modifier = Modifier;
            var name = Name.ToSnippet(options.Naming);
            string type = Type.ToSnippet(options.Types);

            return separator.Combine(attributes, modifier, type, name, @default);
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
                    ValidateDefaultInvalid.Format(nameof(Default), nameof(Parameter), nameof(Type), Type, nameof(Name), Name),
                    new[] { nameof(Default) }));
            }

            return validationContext
                .IncludeIf(!Attributes.IsDefaultOrEmpty, nameof(Attributes), attribute => !attribute.IsUnspecified, results, Attributes)
                .And(nameof(Name), _ => !Name.IsUnnamed, Name)
                .And(nameof(Type), _ => !Type.IsUndefined, Type)
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