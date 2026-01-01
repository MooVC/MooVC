namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using MooVC.Syntax.CSharp.Elements;
    using MooVC.Syntax.Elements;
    using MooVC.Syntax.Validation;

    /// <summary>
    /// Represents a c# generic syntax base.
    /// </summary>
    [Monify(Type = typeof(Symbol))]
    [SkipAutoInstantiation]
    public sealed partial class Base
        : IValidatableObject
    {
        /// <summary>
        /// Gets the unspecified on the Base.
        /// </summary>
        public static readonly Base Unspecified = Symbol.Undefined;

        /// <summary>
        /// Gets a value indicating whether the Base is unspecified.
        /// </summary>
        public bool IsUnspecified => this == Unspecified;

        /// <summary>
        /// Defines the string operator for the Base.
        /// </summary>
        public static implicit operator string(Base @base)
        {
            Guard.Against.Conversion<Base, string>(@base);

            return @base.ToString();
        }

        /// <summary>
        /// Defines the Snippet operator for the Base.
        /// </summary>
        public static implicit operator Snippet(Base @base)
        {
            Guard.Against.Conversion<Base, Snippet>(@base);

            return Snippet.From(@base);
        }

        /// <summary>
        /// Returns the string representation of the Base.
        /// </summary>
        public override string ToString()
        {
            return _value.ToString();
        }

        /// <summary>
        /// Validates the Base and returns validation results.
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsUnspecified)
            {
                return Enumerable.Empty<ValidationResult>();
            }

            return _value.Validate(validationContext);
        }
    }
}