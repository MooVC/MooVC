namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Members;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;
    using static MooVC.Syntax.CSharp.Generics.Constraints.Interface_Resources;

    /// <summary>
    /// Represents a C# generic syntax interface.
    /// </summary>
    [Monify(Type = typeof(Declaration))]
    [SkipAutoInitialization]
    public sealed partial class Interface
        : IValidatableObject
    {
        /// <summary>
        /// Gets the undefined instance.
        /// </summary>
        public static readonly Interface Undefined = Declaration.Unspecified;

        /// <summary>
        /// Gets a value indicating whether the Interface is undefined.
        /// </summary>
        /// <value>A value indicating whether the Interface is undefined.</value>
        public bool IsUndefined => this == Undefined;

        /// <summary>
        /// Defines the string operator for the Interface.
        /// </summary>
        /// <param name="@interface">The interface.</param>
        /// <returns>The string.</returns>
        public static implicit operator string(Interface @interface)
        {
            Guard.Against.Conversion<Interface, Snippet>(@interface);

            return @interface.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Interface.
        /// </summary>
        /// <param name="@interface">The interface.</param>
        /// <returns>The snippet.</returns>
        public static implicit operator Snippet(Interface @interface)
        {
            Guard.Against.Conversion<Interface, Snippet>(@interface);

            return Snippet.From(@interface);
        }

        /// <summary>
        /// Returns the string representation of the Interface.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return _value.ToString();
        }

        /// <summary>
        /// Validates the Interface.
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

            yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Interface)), new[] { nameof(Interface) });
        }
    }
}