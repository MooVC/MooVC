namespace MooVC.Syntax.CSharp
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using Valuify;
    using static MooVC.Syntax.CSharp.Directive_Resources;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a preprocessor directive emitted in generated C# code.
    /// </summary>
    [AutoInitializeWith(nameof(Undefined))]
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
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
        public Name Alias { get; internal set; } = Name.Unnamed;

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
        /// Defines an implicit conversion from <see cref="Directive" /> to <see cref="string" />.
        /// </summary>
        /// <param name="directive">The <see cref="Directive" /> value to convert.</param>
        /// <returns>The converted <see cref="string" /> value.</returns>
        public static implicit operator string(Directive directive)
        {
            Guard.Against.Conversion<Directive, string>(directive);

            return directive.ToString();
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Directive" /> to <see cref="Snippet" />.
        /// </summary>
        /// <param name="directive">The <see cref="Directive" /> value to convert.</param>
        /// <returns>The converted <see cref="Snippet" /> value.</returns>
        public static implicit operator Snippet(Directive directive)
        {
            Guard.Against.Conversion<Directive, Snippet>(directive);

            return Snippet.From(directive);
        }

        /// <summary>
        /// Defines an implicit conversion from <see cref="Qualifier" /> to <see cref="Directive" />.
        /// </summary>
        /// <param name="qualifier">The <see cref="Qualifier" /> value to convert.</param>
        /// <returns>The converted <see cref="Directive" /> value.</returns>
        public static implicit operator Directive(Qualifier qualifier)
        {
            Guard.Against.Conversion<Qualifier, Directive>(qualifier);

            return new Directive()
                .From(qualifier);
        }

        public static implicit operator Directive((string Alias, Qualifier Qualifier) directive)
        {
            Guard.Against.Conversion<(string Alias, Qualifier Qualifier), Directive>(directive);

            return new Directive()
                .From(directive.Qualifier)
                .KnownAs(directive.Alias);
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
                return $"{Alias} =";
            }

            return string.Empty;
        }

        private string GetDebuggerDisplay()
        {
            return $"{nameof(Directive)} {{ " +
                $"{nameof(Alias)} = `{DebuggerDisplayFormatter.Format(Alias)}`, " +
                $"{nameof(IsStatic)} = `{DebuggerDisplayFormatter.Format(IsStatic)}`, " +
                $"{nameof(IsSystem)} = `{DebuggerDisplayFormatter.Format(IsSystem)}`, " +
                $"{nameof(IsUndefined)} = `{DebuggerDisplayFormatter.Format(IsUndefined)}`, " +
                $"{nameof(Qualifier)} = `{DebuggerDisplayFormatter.Format(Qualifier)}` }}";
        }
    }
}