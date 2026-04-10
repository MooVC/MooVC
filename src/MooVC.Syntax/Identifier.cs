namespace MooVC.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.Identifier_Resources;
    using Strings = MooVC.Syntax.Formatting.StringExtensions;

    /// <summary>
    /// Represents a syntax element identifier.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Identifier
        : IComparable<Identifier>,
          IValidatableObject
    {
        /// <summary>
        /// Represents the unnamed for the Identifier.
        /// </summary>
        public static readonly Identifier Unnamed = string.Empty;

        private static readonly Regex _rule = new Regex(@"^(?!\d)(?!.*[^A-Za-z0-9])(?:[A-Z][a-zA-Z0-9]*)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static readonly Dictionary<Casing, Func<string, string>> _strategies = new Dictionary<Casing, Func<string, string>>
        {
            { Casing.Pascal, Strings.ToPascalCase },
            { Casing.Camel, Strings.ToCamelCase },
            { Casing.Snake, Strings.ToSnakeCase },
            { Casing.Kebab, Strings.ToKebabCase },
        };

        /// <summary>
        /// Initializes a new instance of the Identifier class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Identifier(string value)
        {
            _value = value ?? string.Empty;
        }

        /// <summary>
        /// Gets a value indicating whether the Identifier is unnamed.
        /// </summary>
        /// <value>A value indicating whether the Identifier is unnamed.</value>
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Defines the string operator for the Identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Identifier identifier)
        {
            Guard.Against.Conversion<Identifier, string>(identifier);

            return identifier.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Identifier.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Identifier identifier)
        {
            Guard.Against.Conversion<Identifier, Snippet>(identifier);

            return Snippet.From(identifier.ToString());
        }

        /// <summary>
        /// Defines the less than operator for the Identifier.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <(Identifier left, Identifier right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the greater than operator for the Identifier.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >(Identifier left, Identifier right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the less than or equal to operator for the Identifier.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <=(Identifier left, Identifier right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Identifier.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >=(Identifier left, Identifier right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Identifier to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Identifier other)
        {
            return other is null
                ? 1
                : string.CompareOrdinal(_value, other._value);
        }

        /// <summary>
        /// Returns the string representation of the Identifier.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Pascal);
        }

        /// <summary>
        /// Creates a snippet representation of the syntax element.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Identifier)));

            if (IsUnnamed)
            {
                return Snippet.Empty;
            }

            if (!_strategies.TryGetValue(options.Casing, out Func<string, string> transform))
            {
                throw new NotSupportedException(ToStringCasingNotSupported.Format(options.Casing, nameof(Identifier)));
            }

            return transform(_value);
        }

        /// <summary>
        /// Validates the Identifier.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed)
            {
                yield break;
            }

            const int Unspecified = 0;

            if (_value is null || _value.Length == Unspecified || !_rule.IsMatch(_value))
            {
                yield return new ValidationResult(
                    ValidateValueRequired.Format(_value, nameof(Identifier)),
                    new[] { nameof(Identifier) });
            }
        }
    }
}