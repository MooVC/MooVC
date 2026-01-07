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
    /// Represents a C# parameter declaration, including modifier, type, name, and default value.
    /// </summary>
    [AutoInitiateWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Parameter
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined parameter instance used as a placeholder.
        /// </summary>
        public static readonly Parameter Undefined = new Parameter();

        /// <summary>
        /// Initializes a new instance of the Parameter class.
        /// </summary>
        internal Parameter()
        {
        }

        /// <summary>
        /// Gets the attribute list applied to the parameter.
        /// </summary>
        /// <value>The attributes emitted before the parameter declaration.</value>
        public ImmutableArray<Attribute> Attributes { get; internal set; } = ImmutableArray<Attribute>.Empty;

        /// <summary>
        /// Gets the default value snippet for optional parameters.
        /// </summary>
        /// <value>The default value expression snippet.</value>
        public Snippet Default { get; internal set; } = Snippet.Empty;

        /// <summary>
        /// Gets a value indicating whether this parameter is the undefined sentinel.
        /// </summary>
        /// <value>A value indicating whether this instance is the undefined sentinel.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets the parameter modifier (in, ref, out, params, scoped, this).
        /// </summary>
        /// <value>The parameter modifier that affects passing semantics.</value>
        public Mode Modifier { get; internal set; } = Mode.None;

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        /// <value>The parameter identifier.</value>
        [Descriptor("Named")]
        public Variable Name { get; internal set; } = Variable.Unnamed;

        /// <summary>
        /// Gets the parameter type symbol.
        /// </summary>
        /// <value>The parameter type symbol.</value>
        [Descriptor("OfType")]
        public Symbol Type { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Converts the parameter declaration to its C# source representation.
        /// </summary>
        /// <param name="parameter">The parameter declaration to render.</param>
        /// <returns>The rendered parameter text.</returns>
        public static implicit operator string(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, string>(parameter);

            return parameter.ToString();
        }

        /// <summary>
        /// Converts the parameter declaration to a snippet for composition.
        /// </summary>
        /// <param name="parameter">The parameter declaration to convert.</param>
        /// <returns>The snippet representing the parameter declaration.</returns>
        public static implicit operator Snippet(Parameter parameter)
        {
            Guard.Against.Conversion<Parameter, Snippet>(parameter);

            return Snippet.From(parameter);
        }

        /// <summary>
        /// Returns the C# source representation of the parameter declaration.
        /// </summary>
        /// <returns>The rendered parameter text.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Camel);
        }

        /// <summary>
        /// Creates a snippet representation of the parameter declaration.
        /// </summary>
        /// <param name="options">The formatting options for the parameter.</param>
        /// <returns>The parameter declaration snippet.</returns>
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
        /// Validates the parameter declaration before rendering.
        /// </summary>
        /// <remarks>
        /// Ensures the parameter has a name and type, attributes are valid, and the default value is a single-line expression.
        /// </remarks>
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