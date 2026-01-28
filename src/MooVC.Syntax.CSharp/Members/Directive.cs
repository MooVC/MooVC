namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Members.Directive_Resources;
    using Identifier = MooVC.Syntax.Elements.Identifier;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a C# member syntax directive.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [Fluentify]
    [Valuify]
    public sealed partial class Directive
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Directive Undefined = new Directive();
        private const string Separator = " ";

        /// <summary>
        /// Initializes a new instance of the Directive class.
        /// </summary>
        internal Directive()
        {
        }

        /// <summary>
        /// Gets the alias on the Directive.
        /// </summary>
        /// <value>The alias.</value>
        [Descriptor("KnownAs")]
        public Identifier Alias { get; internal set; } = Identifier.Unnamed;

        /// <summary>
        /// Gets a value indicating whether the Directive is undefined.
        /// </summary>
        /// <value>A value indicating whether the Directive is undefined.</value>
        [Ignore]
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Gets a value indicating whether the Directive is static.
        /// </summary>
        /// <value>A value indicating whether the Directive is static.</value>
        public bool IsStatic { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the Directive is system.
        /// </summary>
        /// <value>A value indicating whether the Directive is system.</value>
        [Ignore]
        public bool IsSystem => Qualifier.Length > 0 && Qualifier[0] == nameof(System);

        /// <summary>
        /// Gets the qualifier on the Directive.
        /// </summary>
        /// <value>The qualifier.</value>
        [Descriptor("From")]
        public Qualifier Qualifier { get; internal set; }

        /// <summary>
        /// Defines the string operator for the Directive.
        /// </summary>
        /// <param name="directive">The directive.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Directive directive)
        {
            Guard.Against.Conversion<Directive, string>(directive);

            return directive.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Directive.
        /// </summary>
        /// <param name="directive">The directive.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Directive directive)
        {
            Guard.Against.Conversion<Directive, Snippet>(directive);

            return Snippet.From(directive);
        }

        /// <summary>
        /// Returns the string representation of the Directive.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            if (IsUndefined)
            {
                return string.Empty;
            }

            string prefix = GetPrefix();
            string qualifier = Qualifier.ToString();
            string combined = Separator.Combine("using", prefix, qualifier);

            return string.Concat(combined, ";");
        }

        /// <summary>
        /// Creates a snippet representation of the C# member syntax.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Snippet.Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Snippet.Options), nameof(Qualifier), nameof(Directive)));

            if (IsUndefined)
            {
                return Snippet.Empty;
            }

            return Snippet.From(options, ToString());
        }

        /// <summary>
        /// Validates the Directive.
        /// </summary>
        /// <remarks>Required members include: Alias, Qualifier.</remarks>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUndefined)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            IEnumerable<ValidationResult> results = Enumerable.Empty<ValidationResult>();

            if (IsStatic && !Alias.IsUnnamed)
            {
                results = results.Append(new ValidationResult(
                    ValidateStaticAliasInvalid.Format(Alias, nameof(Alias), Qualifier, nameof(Qualifier)),
                    new[] { nameof(Alias) }));
            }

            return validationContext
                .Include(nameof(Alias), results, Alias)
                .And(nameof(Qualifier), Qualifier)
                .Results;
        }

        private string GetPrefix()
        {
            if (IsStatic)
            {
                return "static";
            }

            if (!Alias.IsUnnamed)
            {
                return $"{Alias.ToSnippet(Identifier.Options.Pascal)} =";
            }

            return string.Empty;
        }
    }
}