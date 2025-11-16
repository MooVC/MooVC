namespace MooVC.Syntax.CSharp.Generics.Constraints
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Fluentify;
    using Monify;
    using MooVC.Linq;
    using MooVC.Syntax.CSharp.Members;
    using static MooVC.Syntax.CSharp.Generics.Constraints.Interface_Resources;

    [Monify(Type = typeof(Declaration))]
    [SkipAutoInstantiation]
    public sealed partial class Interface
        : IValidatableObject
    {
        public override string ToString()
        {
            return _value.ToString();
        }

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