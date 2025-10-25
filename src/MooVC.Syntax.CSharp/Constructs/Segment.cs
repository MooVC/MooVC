namespace MooVC.Syntax.CSharp.Constructs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Monify;
    using static MooVC.Syntax.CSharp.Constructs.Segment_Resources;

    [Monify(Type = typeof(string))]
    public sealed partial class Segment
        : IValidatableObject
    {
        private static readonly Regex rule = new Regex(@"^@?[A-Z][A-Za-z0-9_]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public override string ToString()
        {
            return _value;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const int Empty = 0;

            if (_value is null || _value.Length == Empty || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Segment)), new[] { nameof(Segment) });
            }
        }
    }
}