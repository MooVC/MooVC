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
        [Ignore]
        public abstract bool IsUndefined { get; }

        /// <summary>
        /// Validates the Construct and returns validation results.
        /// </summary>
        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}