namespace MooVC.Syntax.CSharp.Members
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;
    using Ardalis.GuardClauses;
    using Fluentify;
    using Monify;
    using static MooVC.Syntax.CSharp.Members.Segment_Resources;

    [Monify(Type = typeof(string))]
    [SkipAutoInstantiation]
    public sealed partial class Segment
        : IValidatableObject
    {
        public static readonly Segment Empty = string.Empty;

        private static readonly Regex rule = new Regex(@"^@?[A-Z][A-Za-z0-9_]*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public bool IsEmpty => this == Empty;

        public static implicit operator string(Segment segment)
        {
            Guard.Against.Conversion<Segment, string>(segment);

            return segment.ToString();
        }

        public static implicit operator Snippet(Segment segment)
        {
            Guard.Against.Conversion<Segment, Snippet>(segment);

            return Snippet.From(segment);
        }

        public override string ToString()
        {
            return _value;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (IsEmpty)
            {
                yield break;
            }

            const int Unspecified = 0;

            if (_value is null || _value.Length == Unspecified || !rule.IsMatch(_value))
            {
                yield return new ValidationResult(ValidateValueRequired.Format(_value, nameof(Segment)), new[] { nameof(Segment) });
            }
        }
    }
}