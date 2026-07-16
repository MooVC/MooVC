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
    using static MooVC.Syntax.Name_Resources;

    /// <summary>
    /// Represents a syntax element segment.
    /// </summary>
    /// <remarks>
    /// Implicit conversions create an instance from syntax name segment text (<see langword="string" />), such as a
    /// type or member name. The value is validated as a Pascal-cased source identifier segment.
    /// </remarks>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Name
        : IValidatableObject
    {
        /// <summary>
        /// Gets the empty instance.
        /// </summary>
        public static readonly Name Unnamed = string.Empty;
        private static readonly Regex _rule = new Regex(
            @"^@?[A-Z][A-Za-z0-9_]*$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant,
            TimeSpan.FromSeconds(1));

        /// <summary>
        /// Gets a value indicating whether the Segment is empty.
        /// </summary>
        /// <value>A value indicating whether the Segment is empty.</value>
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Defines the string operator for the Name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Name name)
        {
            Guard.Against.Conversion<Name, string>(name);

            return name.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Name name)
        {
            Guard.Against.Conversion<Name, Snippet>(name);

            return Snippet.From(name.ToString());
        }

        /// <summary>
        /// Validates the Segment.
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
                    ValidateValueRequired.Format(_value, nameof(Name)),
                    new[] { nameof(Name) });
            }
        }
    }
}