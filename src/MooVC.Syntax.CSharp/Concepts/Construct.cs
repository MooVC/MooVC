namespace MooVC.Syntax.CSharp.Concepts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ignore = Valuify.IgnoreAttribute;

    public abstract class Construct
        : IValidatableObject
    {
        private protected Construct()
        {
        }

        [Ignore]
        public abstract bool IsUndefined { get; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}