namespace MooVC.Syntax.CSharp.Constructs
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Ardalis.GuardClauses;
    using Monify;
    using static MooVC.Syntax.CSharp.Constructs.Qualifier_Resources;

    [Monify(Type = typeof(ImmutableArray<Segment>))]
    public partial class Qualifier
        : IValidatableObject
    {
        private const string Separator = ".";

        public static implicit operator Qualifier(Segment[] values)
        {
            _ = Guard.Against.Null(values, message: ValuesRequired.Format(nameof(Segment), nameof(Qualifier)));

            return ImmutableArray.Create(values);
        }

        public static implicit operator Segment[](Qualifier qualifier)
        {
            _ = Guard.Against.Null(qualifier, message: QualifierRequired.Format(nameof(Qualifier), nameof(Segment)));

            return qualifier._value.ToArray();
        }

        public override string ToString()
        {
            return string.Join(Separator, _value);
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (_value.IsDefaultOrEmpty)
            {
                return new[]
                {
                    new ValidationResult(ValidateValueRequired.Format(nameof(Qualifier), nameof(Segment)), new[] { nameof(Qualifier) }),
                };
            }

            return Validate(_value);
        }

        private static IEnumerable<ValidationResult> Validate(ImmutableArray<Segment> segments)
        {
            var processed = new List<Segment>();

            for (int index = 0; index < segments.Length; index++)
            {
                Segment value = segments[index];

                if (value is null)
                {
                    string preceding = string.Join(Separator, processed);

                    yield return new ValidationResult(
                        ValidateSegmentRequired.Format(index, nameof(Qualifier), preceding),
                        new[] { $"{nameof(Qualifier)}[{index}]" });
                }
                else
                {
                    value = "{Undefined}";
                }

                processed.Add(value);
            }
        }
    }
}