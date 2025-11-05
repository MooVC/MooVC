namespace MooVC.Syntax.CSharp.Containers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class Construct
        : IValidatableObject
    {
        private protected Construct()
        {
        }

        public abstract bool IsUndefined { get; }

        public abstract IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
    }
}