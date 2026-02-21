namespace MooVC.Syntax.CSharp.Elements
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Formatting;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Elements.Variable_Resources;

    /// <summary>
    /// Represents a C# syntax element variable.
    /// </summary>
    [Monify(Type = typeof(Identifier))]
    [SkipAutoInitialization]
    public sealed partial class Variable
        : IComparable<Variable>,
          IValidatableObject
    {
        /// <summary>
        /// Represents the unnamed for the Variable.
        /// </summary>
        public static readonly Variable Unnamed = Identifier.Unnamed;

        /// <summary>
        /// Initializes a new instance of the Variable class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Variable(Identifier value)
        {
            _value = value ?? Identifier.Unnamed;
        }

        /// <summary>
        /// Gets a value indicating whether the Variable is unnamed.
        /// </summary>
        /// <value>A value indicating whether the Variable is unnamed.</value>
        public bool IsUnnamed => this == Unnamed;

        /// <summary>
        /// Defines the string operator for the Variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Variable variable)
        {
            Guard.Against.Conversion<Variable, string>(variable);

            return variable.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Variable.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Variable variable)
        {
            Guard.Against.Conversion<Variable, Snippet>(variable);

            return variable.ToSnippet(Options.Camel);
        }

        /// <summary>
        /// Defines the less than operator for the Variable.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <(Variable left, Variable right)
        {
            if (left is null)
            {
                return right is object;
            }

            return left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Defines the greater than operator for the Variable.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >(Variable left, Variable right)
        {
            if (left is null)
            {
                return false;
            }

            return left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Defines the less than or equal to operator for the Variable.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator <=(Variable left, Variable right)
        {
            return !(left > right);
        }

        /// <summary>
        /// Defines the greater than or equal to operator for the Variable.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The .</returns>
        public static bool operator >=(Variable left, Variable right)
        {
            return !(left < right);
        }

        /// <summary>
        /// Compares this Variable to another instance.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>A signed integer indicating relative order.</returns>
        public int CompareTo(Variable other)
        {
            return other is null
                ? 1
                : string.CompareOrdinal(_value, other._value);
        }

        /// <summary>
        /// Returns the string representation of the Variable.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return ToSnippet(Options.Camel);
        }

        /// <summary>
        /// Creates a snippet representation of the C# syntax element.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>The generated snippet.</returns>
        public Snippet ToSnippet(Options options)
        {
            _ = Guard.Against.Null(options, message: ToSnippetOptionsRequired.Format(nameof(Variable)));

            string value = _value.ToSnippet(options);

            if (Aliases.IsSystem(value))
            {
                return value.ToCamelCase();
            }

            const char ReservationPrefix = '@';
            const char UnderscorePrefix = '_';

            var identifier = new StringBuilder(value);

            if (options.UseUnderscore)
            {
                identifier = identifier.Prepend(UnderscorePrefix);
            }
            else if (options.Casing != Identifier.Casing.Pascal && identifier.IsReserved())
            {
                identifier = identifier.Prepend(ReservationPrefix);
            }

            return identifier.ToString();
        }

        /// <summary>
        /// Validates the Variable.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnnamed || Aliases.IsSystem(_value))
            {
                yield break;
            }

            foreach (ValidationResult result in _value.Validate(validationContext))
            {
                yield return new ValidationResult(result.ErrorMessage, new[] { nameof(Variable) });
            }
        }
    }
}