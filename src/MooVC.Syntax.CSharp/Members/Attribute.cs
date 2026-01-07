namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Attribute_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax attribute.
    /// </summary>
    [AutoInitiateWith(nameof(Unspecified))]
    [Fluentify]
    [Valuify]
    public sealed partial class Attribute
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Attribute Unspecified = new Attribute();
        private static readonly Snippet separator = Snippet.From(", ");

        /// <summary>
        /// Initializes a new instance of the Attribute class.
        /// </summary>
        internal Attribute()
        {
        }

        /// <summary>
        /// Gets or sets the arguments on the Attribute.
        /// </summary>
        /// <value>The arguments.</value>
        public ImmutableArray<Argument> Arguments { get; internal set; } = ImmutableArray<Argument>.Empty;

        /// <summary>
        /// Gets a value indicating whether the Attribute is unspecified.
        /// </summary>
        /// <value>A value indicating whether the Attribute is unspecified.</value>
        [Ignore]
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Gets or sets the name on the Attribute.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Symbol Name { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets or sets the target on the Attribute.
        /// </summary>
        /// <value>The target.</value>
        public Specifier Target { get; internal set; } = Specifier.None;

        /// <summary>
        /// Defines the string operator for the Attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Attribute attribute)
        {
            Guard.Against.Conversion<Attribute, string>(attribute);

            return attribute.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Attribute attribute)
        {
            Guard.Against.Conversion<Attribute, Snippet>(attribute);

            return attribute.ToSnippet(Snippet.Options.Default);
        }

        /// <summary>
        /// Returns the string representation of the Attribute.
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
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Arguments), nameof(Attribute)));

            if (Name.IsUndefined)
            {
                return Snippet.Empty;
            }

            var value = new StringBuilder();

            if (Target != Specifier.None)
            {
                value = value.Append($"{Target}:");
            }

            value = value.Append(Name);

            if (!Arguments.IsDefaultOrEmpty)
            {
                value = AppendArguments(options, value);
            }

            return Snippet.From(options, $"[{value}]");
        }

        /// <summary>
        /// Validates the Attribute.
        /// </summary>
        /// <remarks>Required members include: Arguments, Name.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return validationContext
                .IncludeIf(!Arguments.IsDefaultOrEmpty, nameof(Arguments), argument => !argument.IsUndefined, Arguments)
                .And(nameof(Name), _ => !Name.IsUndefined, Name)
                .Results;
        }

        private StringBuilder AppendArguments(Snippet.Options options, StringBuilder value)
        {
            Argument.Options declaration = Argument.Options.Declaration.WithSnippet(options);

            Snippet[] arguments = Arguments
                .Select(argument => argument.ToSnippet(declaration))
                .ToArray();

            Snippet syntax = separator.Combine(options, arguments);

            return value.Append($"({syntax})");
        }
    }
}