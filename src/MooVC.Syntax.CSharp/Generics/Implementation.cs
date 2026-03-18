namespace MooVC.Syntax.CSharp.Generics
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Generics.Implementation_Resources;

    /// <summary>
    /// Represents a C# generic syntax implementation.
    /// </summary>
    [Monify(Type = typeof(Declaration))]
    [SkipAutoInitialization]
    public sealed partial class Implementation
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Implementation Undefined = Declaration.Unspecified;

        internal Implementation(Declaration declaration)
        {
            _value = declaration ?? Declaration.Unspecified;
        }

        /// <summary>
        /// Gets a value indicating whether the implementation is undefined.
        /// </summary>
        /// <value>A value indicating whether the implementation is undefined.</value>
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Defines the string operator for the implementation.
        /// </summary>
        /// <param name="implementation">The implementation.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Implementation implementation)
        {
            Guard.Against.Conversion<Implementation, Snippet>(implementation);

            return implementation.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the implementation.
        /// </summary>
        /// <param name="implementation">The implementation.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Implementation implementation)
        {
            Guard.Against.Conversion<Implementation, Snippet>(implementation);

            return Snippet.From(implementation);
        }

        /// <summary>
        /// Returns the string representation of the implementation.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value.ToString();
        }

        /// <summary>
        /// Validates the implementation.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            string name = _value.ToString();

            const int MinimumRequired = 1;

            if (name.Length > MinimumRequired && name.StartsWith("I", StringComparison.Ordinal) && _value.Validate(validationContext).IsEmpty())
            {
                yield break;
            }

            yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Implementation)), new[] { nameof(Implementation) });
        }
    }
}