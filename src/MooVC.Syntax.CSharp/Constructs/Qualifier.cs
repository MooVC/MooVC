namespace MooVC.Syntax.CSharp.Constructs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Monify;
    using static MooVC.Syntax.CSharp.Constructs.Qualifier_Resources;

    [Monify(Type = typeof(Segment[]))]
    public sealed partial class Qualifier
        : IValidatableObject
    {
        public override string ToString()
        {
            if (_value is null)
            {
                return null;
            }

            if (_value.Length == 0)
            {
                return string.Empty;
            }

            return string.Join('.', _value.Select(segment => segment?.ToString()));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (_value is null || _value.Length == 0)
            {
                yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Qualifier)), new[] { nameof(Qualifier) });

                yield break;
            }

            for (int index = 0; index < _value.Length; index++)
            {
                Segment? segment = _value[index];

                if (segment is null)
                {
                    yield return new ValidationResult(ValidateSegmentRequired.Format(nameof(Qualifier)), new[] { nameof(Qualifier) });

                    yield break;
                }

                var results = new List<ValidationResult>();

                if (!Validator.TryValidateObject(segment, new ValidationContext(segment), results, validateAllProperties: true))
                {
                    string message = results.FirstOrDefault()?.ErrorMessage ?? ValidateSegmentRequired.Format(nameof(Qualifier));

                    yield return new ValidationResult(message, new[] { nameof(Qualifier) });

                    yield break;
                }
            }
        }
    }
}
