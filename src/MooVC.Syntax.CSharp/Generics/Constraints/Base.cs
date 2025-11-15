namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Monify;
    using MooVC.Syntax.CSharp.Members;

    [Monify(Type = typeof(Symbol))]
    public sealed partial class Base
        : IValidatableObject
    {
        public static readonly Base Unspecified = Symbol.Unspecified;

        public bool IsUnspecified => this == Unspecified;

        public override string ToString()
        {
            return _value.ToString();
        }

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