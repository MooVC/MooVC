namespace MooVC.Syntax
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a base type for syntax constructs.
    /// </summary>
    /// <remarks>
    /// Derived types expose domain-specific state and validation while sharing a common undefined-state contract.
    /// </remarks>
    public abstract class Construct
        : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the Construct class.
        /// </summary>
        protected Construct()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the construct represents an undefined value.
        /// </summary>
        /// <value>
        /// <see langword="true"/> when the current instance is an undefined sentinel; otherwise, <see langword="false"/>.
        /// </value>
        [Ignore]
        [SuppressMessage("Usage", "VALFY04:Type does not utilize Valuify", Justification = "The derived class will be annotated with it.")]
        public abstract bool IsUndefined { get; }

        /// <summary>
        /// Validates the construct.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A sequence containing all validation failures for the current instance.</returns>
        /// <remarks>
        /// Implementations should return an empty sequence when no validation failures are present.
        /// </remarks>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}