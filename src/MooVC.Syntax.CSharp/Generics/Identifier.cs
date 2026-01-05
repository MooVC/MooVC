namespace MooVC.Syntax.CSharp.Generics
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Generics.Identifier_Resources;

    /// <summary>
    /// Represents a C# generic syntax identifier.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Identifier
        : IValidatableObject
    {
        /// <summary>
        /// Represents the unnamed for the Identifier.
        /// </summary>
        public static readonly Identifier Unnamed = string.Empty;
        private static readonly Regex rule = new Regex(@"^T(?:[A-Z][A-Za-z0-9]*)?$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

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

            return Snippet.From(identifier);
        }

        /// <summary>
        /// Returns the string representation of the Identifier.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
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

            if (_value is null || _value.Length == Unspecified || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(
                    ValidateValueRequired.Format(_value, nameof(Identifier)),
                    new[] { nameof(Identifier) });
            }
        }
    }
}