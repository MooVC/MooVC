namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Valuify;

    [Fluentify]
    [Valuify]
    public sealed partial class Property
        : IValidatableObject
    {
        public static readonly Property Undefined = new Property();

        public bool IsUndefined => this == Undefined;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}