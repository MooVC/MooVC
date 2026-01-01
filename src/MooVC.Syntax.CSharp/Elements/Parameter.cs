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

    /// <summary>
    /// Represents a c# syntax element parameter.
    /// </summary>
    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined on the Parameter.
        /// </summary>
        public static readonly Parameter Undefined = new Parameter();

        /// <summary>
        /// Initializes a new instance of the Parameter class.
        /// </summary>
        internal Parameter()
        {
        }

        /// <summary>
        /// Gets or sets the attributes on the Parameter.
        /// </summary>
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets or sets the default on the Parameter.
        /// </summary>
        public Snippet Default { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether the Parameter is undefined.
        /// </summary>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets or sets the modifier on the Parameter.
        /// </summary>
        public Mode Modifier { get; internal set; } = Mode.None;

        /// <summary>
        /// Gets or sets the name on the Parameter.
        /// </summary>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets or sets the type on the Parameter.
        /// </summary>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Defines the string operator for the Parameter.
        /// </summary>
        public static implicit operator string(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, string>(parameter);

            return parameter.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Parameter.
        /// </summary>
        public static implicit operator Snippet(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, Snippet>(parameter);

            return Snippet.From(parameter);
        }

        /// <summary>
        /// Returns the string representation of the Parameter.
        /// </summary>
        public override string ToString()
        {
            return ToSnippet(Options.Camel);
        }

        /// <summary>
        /// Creates a code snippet representation of the c# syntax element.
        /// </summary>
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

        /// <summary>
        /// Validates the Parameter and returns validation results.
        /// </summary>
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