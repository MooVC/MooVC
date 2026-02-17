namespace MooVC.Syntax.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.Elements.Name_Resources;

    /// <summary>
    /// Represents a syntax element segment.
    /// </summary>
    [Monify(Type = typeof(string))]
    [SkipAutoInitialization]
    public sealed partial class Name
        : IComparable<Name>,
          IValidatableObject
    {
        /// <summary>
        /// Gets the empty instance.
        /// </summary>
        public static readonly Name Unnamed = string.Empty;
        private static readonly Regex rule = new Regex(@"^@?[A-Z][A-Za-z0-9_]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Gets a value indicating whether the Segment is empty.
        /// </summary>
        /// <value>A value indicating whether the Segment is empty.</value>
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Defines the string operator for the Segment.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Name segment)
        {
            Guard.Against.Conversion<Name, string>(segment);

            return segment.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Segment.
        /// </summary>
        /// <param name="segment">The segment.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Name segment)
        {
            Guard.Against.Conversion<Name, Snippet>(segment);

            return Snippet.From(segment);
        }

        /// <summary>
        /// Defines the less than operator for the Segment.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <(Name left, Name right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the greater than operator for the Segment.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >(Name left, Name right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the less than or equal to operator for the Segment.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <=(Name left, Name right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Segment.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >=(Name left, Name right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Segment to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Name other)
        {
            return other is null
                ? 1
                : string.CompareOrdinal(_value, other._value);
        }

        /// <summary>
        /// Returns the string representation of the Segment.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value;
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

            if (_value is null || _value.Length == Unspecified || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(
                    ValidateValueRequired.Format(_value, nameof(Name)),
                    new[] { nameof(Name) });
            }
        }
    }
}