namespace MooVC.Syntax.Concepts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ignore = Valuify.IgnoreAttribute;

    /// <summary>
    /// Represents a syntax construct construct.
    /// </summary>
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
        /// Gets a value indicating whether the Construct is undefined.
        /// </summary>
        /// <value>A value indicating whether the Construct is undefined.</value>
        [Ignore]
        public abstract bool IsUndefined { get; }

        /// <summary>
        /// Validates the Construct.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The validation results.</returns>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}