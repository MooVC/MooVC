namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Linq;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Attribute_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax attribute.
    /// </summary>
    [AutoInitializeWith(nameof(Unspecified))]
    [Fluentify]
    [Valuify]
    public sealed partial class Attribute
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified instance.
        /// </summary>
        public static readonly Attribute Unspecified = new Attribute();

        private const int SuffixLength = 9;
        private static readonly string _separator = ", ";

        /// <summary>
        /// Initializes a new instance of the Attribute class.
        /// </summary>
        internal Attribute()
        {
        }

        /// <summary>
        /// Gets the arguments on the Attribute.
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
        /// Gets the name on the Attribute.
        /// </summary>
        /// <value>The name.</value>
        [Descriptor("Named")]
        public Symbol Name { get; internal set; } = Symbol.Undefined;

        /// <summary>
        /// Gets the target on the Attribute.
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

            return attribute.ToSnippet(Options.Separate);
        }

        /// <summary>
        /// Returns the string representation of the Attribute.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Separate);
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Options), nameof(Arguments), nameof(Attribute)));

            if (Name.IsUndefined)
            {
                return Snippet.Empty;
            }

            var value = new StringBuilder();

            if (Target != Specifier.None)
            {
                value = value.Append($"{Target}:");
            }

            string name = Name.ToSnippet(options);

            if (options.Types.Qualification == Symbol.Qualification.Minimum && name.EndsWith(nameof(Attribute)))
            {
                name = name.Substring(0, name.Length - SuffixLength);
            }

            value = value.Append(name);

            if (!Arguments.IsDefaultOrEmpty)
            {
                value = AppendArguments(options, value);
            }

            return Snippet.From(options, value.ToString());
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

            string[] arguments = Arguments
                .Select(argument => argument
                    .ToSnippet(declaration)
                    .ToString())
                .ToArray();

            string content = string.Join(_separator, arguments);
            string snippet = Snippet.From(options, content);

            return value.Append($"({snippet})");
        }
    }
}